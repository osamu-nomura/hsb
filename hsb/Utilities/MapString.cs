using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities
{
    #region 【Static Class : MapString】
    /// <summary>
    /// 文字種変換ユーティリティ
    /// </summary>
    public static class MapString
    {
        #region ■ Enum

        #region - MapFlags : 変換指定フラグ
        /// <summary>
        /// 変換指定フラグ
        /// </summary>
        public enum MapFlags : uint
        {
            NORM_IGNORECASE = 0x00000001,           //大文字と小文字を区別しません。
            NORM_IGNORENONSPACE = 0x00000002,       //送りなし文字を無視します。このフラグをセットすると、日本語アクセント文字も削除されます。
            NORM_IGNORESYMBOLS = 0x00000004,        //記号を無視します。
            LCMAP_LOWERCASE = 0x00000100,           //小文字を使います。
            LCMAP_UPPERCASE = 0x00000200,           //大文字を使います。
            LCMAP_SORTKEY = 0x00000400,             //正規化されたワイド文字並び替えキーを作成します。
            LCMAP_BYTEREV = 0x00000800,             //Windows NT のみ : バイト順序を反転します。たとえば 0x3450 と 0x4822 を渡すと、結果は 0x5034 と 0x2248 になります。
            SORT_STRINGSORT = 0x00001000,           //区切り記号を記号と同じものとして扱います。
            NORM_IGNOREKANATYPE = 0x00010000,       //ひらがなとカタカナを区別しません。ひらがなとカタカナを同じと見なします。
            NORM_IGNOREWIDTH = 0x00020000,          //シングルバイト文字と、ダブルバイトの同じ文字とを区別しません。
            LCMAP_HIRAGANA = 0x00100000,            //ひらがなにします。
            LCMAP_KATAKANA = 0x00200000,            //カタカナにします。
            LCMAP_HALFWIDTH = 0x00400000,           //半角文字にします（適用される場合）。
            LCMAP_FULLWIDTH = 0x00800000,           //全角文字にします（適用される場合）。
            LCMAP_LINGUISTIC_CASING = 0x01000000,   //大文字と小文字の区別に、ファイルシステムの規則（既定値）ではなく、言語上の規則を使います。LCMAP_LOWERCASE、または LCMAP_UPPERCASE とのみ組み合わせて使えます。
            LCMAP_SIMPLIFIED_CHINESE = 0x02000000,  //中国語の簡体字を繁体字にマップします。
            LCMAP_TRADITIONAL_CHINESE = 0x04000000, //中国語の繁体字を簡体字にマップします。
        }
        #endregion

        #endregion

        #region ■ Static Private Methods

        #region - LCMapStringW 
        /// <summary>
        /// WIN32 API : LCMapStringW
        /// </summary>
        /// <param name="Locale"></param>
        /// <param name="dwMapFlags"></param>
        /// <param name="lpSrcStr"></param>
        /// <param name="cchSrc"></param>
        /// <param name="lpDestStr"></param>
        /// <param name="cchDest"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern int LCMapStringW(int Locale, uint dwMapFlags,
            [MarshalAs(UnmanagedType.LPWStr)]string lpSrcStr, int cchSrc,
            [MarshalAs(UnmanagedType.LPWStr)] string lpDestStr, int cchDest);
        #endregion

        #endregion

        #region ■ Staitc Methods

        #region - Convert : 文字種変換処理
        /// <summary>
        /// 文字種変換処理
        /// </summary>
        /// <param name="str">変換元の文字列</param>
        /// <param name="flags">変換種別</param>
        /// <returns>変換後の文字列</returns>
        public static string Convert(string str, MapFlags flags)
        {
            var ci = System.Globalization.CultureInfo.CurrentCulture;
            var result = new string(' ', str.Length);
            LCMapStringW(ci.LCID, (uint)flags, str, str.Length, result, result.Length);
            return result;
        }
        #endregion

        #region - Han2Zen : 半角文字列を全角にする。
        /// <summary>
        /// 半角文字列を全角にする。
        /// </summary>
        /// <param name="str">変換元の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string Han2Zen(string str)
        {
            return Convert(str, MapFlags.LCMAP_FULLWIDTH);
        }
        #endregion

        #region - Zen2Han : 全角文字列を半角にする
        /// <summary>
        /// 全角文字列を半角にする。
        /// </summary>
        /// <param name="s">変換元の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string Zen2Han(string s)
        {
            return Convert(s, MapFlags.LCMAP_HALFWIDTH);
        }
        #endregion

        #region - ZenHirakana2ZenKatakana : 全角ひらがなを全角カナカナにする。
        /// <summary>
        /// 全角ひらがなを全角カナカナにする。
        /// </summary>
        /// <param name="s">変換元の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string ZenHirakana2ZenKatakana(string s)
        {
            return Convert(s, MapFlags.LCMAP_KATAKANA);
        }
        #endregion

        #endregion
    }
    #endregion
}
