using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace hsb.Utilities
{
    #region 【Interface : ISmtpClientCreateParameter】
    /// <summary>
    /// SMTPクライアント生成用パラメーターインターフェイス
    /// </summary>
    public interface ISmtpClientCreateParameter
    {
        #region ■ Properties

        #region - Host : ホスト名
        /// <summary>
        /// ホスト名
        /// </summary>
        string Host { get; }
        #endregion

        #region - Port : ポート番号
        /// <summary>
        /// ポート番号
        /// </summary>
        int Port { get; }
        #endregion

        #region - User : SMTP認証用ユーザーID
        /// <summary>
        /// SMTP認証用ユーザーID
        /// </summary>
        string User { get; }
        #endregion

        #region - Password : SMTP認証用パスワード
        /// <summary>
        /// SMTP認証用パスワード
        /// </summary>
        string Password { get; }
        #endregion

        #region - EnableSsl : SSLを使用する
        /// <summary>
        /// SSLを使用する
        /// </summary>
        bool EnableSsl { get; }
        #endregion

        #endregion
    }
    #endregion

    #region 【Class : SmtpClientCreateParameter】
    /// <summary>
    /// SMTPクライアント生成用パラメータークラス
    /// </summary>
    public class SmtpClientCreateParameter : ISmtpClientCreateParameter
    {
        #region ■ Properties

        #region - Host : ホスト名
        /// <summary>
        /// ホスト名
        /// </summary>
        public string Host { get; set; }
        #endregion

        #region - Port : ポート番号
        /// <summary>
        /// ポート番号
        /// </summary>
        public int Port { get; set; }
        #endregion

        #region - User : SMTP認証用ユーザーID
        /// <summary>
        /// SMTP認証用ユーザーID
        /// </summary>
        public string User { get; set; }
        #endregion

        #region - Password : SMTP認証用パスワード
        /// <summary>
        /// SMTP認証用パスワード
        /// </summary>
        public string Password { get; set; }
        #endregion

        #region - EnableSsl : SSLを使用する
        /// <summary>
        /// SSLを使用する
        /// </summary>
        public bool EnableSsl { get; set; } = false;
        #endregion

        #endregion
    }
    #endregion

    #region 【Static Class : MailUtil】
    /// <summary>
    /// メール処理クラス
    /// </summary>
    public static class MailUtil
    {
        #region ■　Static Methods

        #region - CreateSmtpClient : SMTPクライアントを生成する(1)
        /// <summary>
        /// SMTPクライアントを生成する(1)
        /// </summary>
        /// <param name="param">SMTPクライアント生成用パラメーター</param>
        /// <returns>SMTPクライアント</returns>
        public static SmtpClient CreateSmtpClient(this ISmtpClientCreateParameter param)
        {
            if (param == null)
                throw new ArgumentNullException();

            var sc = new SmtpClient
            {
                Host = param.Host,
                Port = param.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            if (!string.IsNullOrEmpty(param.User))
                sc.Credentials = new NetworkCredential(param.User, param.Password);
            sc.EnableSsl = param.EnableSsl;
            return sc;
        }
        #endregion

        #region - CreateSmtpClient : SMTPクライアントを生成する(2)
        /// <summary>
        /// SMTPクライアントを生成する(2)
        /// </summary>
        /// <param name="host">SMTPサーバーホスト名</param>
        /// <param name="port">SMTPサーバーポート番号</param>
        /// <param name="user">SMTP認証用ユーザーID</param>
        /// <param name="password">SMTP認証用パスワード</param>
        /// <returns>SMTPクライアント</returns>
        public static SmtpClient CreateSmtpClient(string host, int port = 25, string user = null, string password = null)
        {
            return CreateSmtpClient(new SmtpClientCreateParameter
            {
                Host = host,
                Port = port,
                User = user,
                Password  = password
            });
        }
        #endregion

        #region - SendMail : メールを送信する(1)
        /// <summary>
        /// メールを送信する(1)
        /// </summary>
        /// <param name="sc">SMTPクライアント</param>
        /// <param name="callback">メッセージ設定コールバック</param>
        public static void SendMail(SmtpClient sc, Action<MailMessage> callback)
        {
            using (var msg = new MailMessage())
            {
                callback(msg);
                sc.Send(msg);
            }
        }
        #endregion

        #region - SendMail : メールを送信する(2)
        /// <summary>
        /// メールを送信する(2)
        /// </summary>
        /// <param name="param">SMTPクライアント生成パラメータ</param>
        /// <param name="callback">メッセージ設定コールバック</param>
        public static void SendMail(this ISmtpClientCreateParameter param, Action<MailMessage> callback)
        {
            using (var sc = CreateSmtpClient(param))
            {
                SendMail(sc, callback);
            }
        }
        #endregion

        #region - SendMail : メールを送信する(3)
        /// <summary>
        /// メールを送信する(3)
        /// </summary>
        /// <param name="sc">SMTPCクライアント</param>
        /// <param name="from">送信元アドレス</param>
        /// <param name="to">送信先アドレス</param>
        /// <param name="subject">件名</param>
        /// <param name="body">本文</param>
        public static void SendMail(SmtpClient sc, string from, IEnumerable<string> to, string subject, string body)
        {
            SendMail(sc, msg =>
            {
                msg.From = new MailAddress(from);
                foreach (var toAddress in to)
                {
                    msg.To.Add(new MailAddress(toAddress));
                }                
                msg.Subject = subject;
                msg.Body = body;
            });
        }
        #endregion

        #region - SendMail : メールを送信する(4)
        /// <summary>
        /// メールを送信する(4)
        /// </summary>
        /// <param name="param">SMTPクライアント生成パラメータ</param>
        /// <param name="from">送信元アドレス</param>
        /// <param name="to">送信先アドレス</param>
        /// <param name="subject">件名</param>
        /// <param name="body">本文</param>
        public static void SendMail(this ISmtpClientCreateParameter param, string from, IEnumerable<string> to, string subject, string body)
        {
            using (var sc = CreateSmtpClient(param))
            {
                SendMail(sc, from, to, subject, body);
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
