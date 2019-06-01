using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace hsb.Utilities
{
    #region 【Static Class : MessageDigest】
    /// <summary>
    /// メッセージダイジェスト関連ユーティリティ
    /// </summary>
    public static class MessageDigest
    {
        #region - CreateDigest : バイト配列のダイジェスト値を取得する
        /// <summary>
        /// バイト配列のダイジェスト値を取得する
        /// </summary>
        /// <param name="ha">HashAlgorithm</param>
        /// <param name="data">バイト配列</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigest(HashAlgorithm ha ,byte[] data)
        {
            var digest = "";
            try
            {
                var hashBytes = ha.ComputeHash(data);
                var sb = new StringBuilder(hashBytes.Length);
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                digest = sb.ToString();
            }
            finally { ha.Clear(); }
            return digest;
        }
        #endregion

        #region - CreateDigest : 文字列のダイジェスト値を取得する
        /// <summary>
        /// 文字列のダイジェスト値を取得する
        /// </summary>
        /// <param name="ha">HashAlgorithm</param>
        /// <param name="s">文字列</param>
        /// <param name="enc">エンコーディング</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigest(HashAlgorithm ha, string s, Encoding enc = null)
            => CreateDigest(ha, (enc ?? Encoding.UTF8).GetBytes(s));
        #endregion

        #region - CreateDigestFromFile : ファイルのダイジェスト値を取得する
        /// <summary>
        /// ファイルのダイジェスト値を取得する
        /// </summary>
        /// <param name="ha">HashAlgorithm</param>
        /// <param name="path">ダイジェスト値を取得するファイルのPATH</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigestFromFile(HashAlgorithm ha, string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found : {path}");
            return CreateDigest(ha, File.ReadAllBytes(path));
        }
        #endregion
    }
    #endregion

    #region 【Static Class : MD5】
    /// <summary>
    /// MD5メッセージダイジェスト関連ユーティリティ
    /// </summary>
    public static class MD5
    {
        #region - CreateDigest : バイト配列からMD5ダイジェスト値を取得する
        /// <summary>
        /// バイト配列からMD5ダイジェスト値を取得する
        /// </summary>
        /// <param name="data">バイト配列</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigest(byte[] data)
            => MessageDigest.CreateDigest(new MD5CryptoServiceProvider(), data);
        #endregion

        #region - CreateDigest : 文字列のMD5ダイジェスト値を取得する
        /// <summary>
        /// 文字列のMD5ダイジェスト値を取得する
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="enc">エンコーディング</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigest(string s, Encoding enc = null)
            => MessageDigest.CreateDigest(new MD5CryptoServiceProvider(), s, enc);
        #endregion

        #region - CreateDigestFromFile : ファイルのMD5ダイジェスト値を取得する
        /// <summary>
        /// ファイルのMD5ダイジェスト値を取得する
        /// </summary>
        /// <param name="path">ダイジェスト値を取得するファイルのPATH</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigestFromFile(string path)
            => MessageDigest.CreateDigestFromFile(new MD5CryptoServiceProvider(), path);
        #endregion
    }
    #endregion

    #region 【Static Class : SHA1】
    /// <summary>
    /// SHA1メッセージダイジェスト関連ユーティリティ
    /// </summary>
    public static class SHA1
    {
        #region - CreateDigest : バイト配列からSHA1ダイジェスト値を取得する
        /// <summary>
        /// バイト配列からSHA1ダイジェスト値を取得する
        /// </summary>
        /// <param name="data">バイト配列</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigest(byte[] data)
            => MessageDigest.CreateDigest(new SHA1CryptoServiceProvider(), data);
        #endregion

        #region - CreateDigest : 文字列のSHA1ダイジェスト値を取得する
        /// <summary>
        /// 文字列のSHA1ダイジェスト値を取得する
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="enc">エンコーディング</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigest(string s, Encoding enc = null)
            => MessageDigest.CreateDigest(new SHA1CryptoServiceProvider(), s, enc);
        #endregion

        #region - CreateDigestFromFile : ファイルのSHA1ダイジェスト値を取得する
        /// <summary>
        /// ファイルのSHA1ダイジェスト値を取得する
        /// </summary>
        /// <param name="path">ダイジェスト値を取得するファイルのPATH</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigestFromFile(string path)
            => MessageDigest.CreateDigestFromFile(new SHA1CryptoServiceProvider(), path);
        #endregion
    }
    #endregion

    #region 【Static Class : SHA256】
    /// <summary>
    /// SHA256メッセージダイジェスト関連ユーティリティ
    /// </summary>
    public static class SHA256
    {
        #region - CreateDigest : バイト配列からSHA256ダイジェスト値を取得する
        /// <summary>
        /// バイト配列からSHA256ダイジェスト値を取得する
        /// </summary>
        /// <param name="data">バイト配列</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigest(byte[] data)
            => MessageDigest.CreateDigest(new SHA256CryptoServiceProvider(), data);
        #endregion

        #region - CreateDigest : 文字列のSHA256ダイジェスト値を取得する
        /// <summary>
        /// 文字列のSHA1ダイジェスト値を取得する
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="enc">エンコーディング</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigest(string s, Encoding enc = null)
            => MessageDigest.CreateDigest(new SHA256CryptoServiceProvider(), s, enc);
        #endregion

        #region - CreateDigestFromFile : ファイルのSHA1ダイジェスト値を取得する
        /// <summary>
        /// ファイルのSHA1ダイジェスト値を取得する
        /// </summary>
        /// <param name="path">ダイジェスト値を取得するファイルのPATH</param>
        /// <returns>ダイジェスト値</returns>
        public static string CreateDigestFromFile(string path)
            => MessageDigest.CreateDigestFromFile(new SHA256CryptoServiceProvider(), path);
        #endregion
    }
    #endregion
}
