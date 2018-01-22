using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using hsb.Extensions;

namespace hsb.Utilities
{
    #region 【Static Class : KanjiNumeralUtil】
    /// <summary>
    /// 漢数字関連ユーティリティ
    /// </summary>
    public static class KanjiNumeralUtil
    {
        #region ■ Contsnats
        /// <summary>
        /// 置換用漢数字
        /// </summary>
        private const string KNJ_NUMERAL = "一二三四五六七八九〇１２３４５６７８９０壱弐参";
        /// <summary>
        /// 対応するアラビア数字
        /// </summary>
        private const string ANK_NUMERAL = "12345678901234567890123";
        #endregion

        #region ■ Members
        /// <summary>
        /// 数字にマッチする正規表現
        /// </summary>
        private static readonly Regex RegNumerals = new Regex(@"[十拾百千万億兆\d]+");
        /// <summary>
        /// アラビア数字にマッチする正規表現
        /// </summary>
        private static readonly Regex RegArabicNumerals = new Regex(@"^[0-9]+$");
        /// <summary>
        /// 千より大きい単位とそれ以下の数字に分割する正規表現
        /// </summary>
        private static readonly Regex RegDivideGtThousand = new Regex(@"[万億兆]|[^万億兆]+");
        /// <summary>
        /// 十以上の単位と数字に分割する正規表現
        /// </summary>
        private static readonly Regex RegDivideDigitUnit = new Regex(@"[十拾百千]|\d+");
        /// <summary>
        /// 単位と桁数を保持する辞書
        /// </summary>
        private static readonly Dictionary<string, long> Digits = new Dictionary<string, long>
        {
            {"十", 10 },
            {"拾", 10 },
            {"百", 100 },
            {"千", 1000 },
            {"万", 10000 },
            {"億", 100000000 },
            {"兆", 1000000000000 }
        };
        #endregion

        #region ■ Static Private Methods

        #region - ConvertArabicNumber : 
        /// <summary>
        /// 漢数字を整数値に変換する
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="reg">正規表現</param>
        /// <returns></returns>
        private static long ConvertKanjiNumeral2Long(string s, Regex reg)
        {
            var unit = 1L;
            var result = 0L;

            foreach (var piece in reg.Matches(s).GetGenericEnumerator().Select(m => m.Value).Reverse())
            {
                if (Digits.ContainsKey(piece))
                {
                    if (unit > 1)
                    {
                        result += unit;
                    }
                    unit = Digits[piece];
                }
                else
                {
                    var val = RegArabicNumerals.IsMatch(piece) ? System.Convert.ToInt64(piece) :
                                                            ConvertKanjiNumeral2Long(piece, RegDivideDigitUnit);
                    result += val * unit;
                    unit = 1;
                }
            }
            if (unit > 1)
                result += unit;
            return result;
        }
        #endregion

        #endregion

        #region ■ Static Methods

        #region - Convert : 漢数字を整数に変換する
        /// <summary>
        /// 漢数字を整数に変換する
        /// </summary>
        /// <param name="knjNumeric"></param>
        /// <returns>整数値</returns>
        public static long Convert(string knjNumeric)
        {
            var s = knjNumeric.Translate(KNJ_NUMERAL, ANK_NUMERAL);
            return ConvertKanjiNumeral2Long(s, RegDivideGtThousand);
        }
        #endregion

        #region - Replace : 文字列中の漢数字をアラビア数字表記に置換する
        /// <summary>
        /// 文字列中の漢数字をアラビア数字表記に置換する
        /// </summary>
        /// <param name="knjNumeral">漢数字を含む文字列</param>
        /// <param name="format">書式</param>
        /// <returns>文字列</returns>
        public static string Replace(string knjNumeral, string format = null)
        {
            if (string.IsNullOrEmpty(knjNumeral))
                return knjNumeral;

            var s = knjNumeral.Translate(KNJ_NUMERAL, ANK_NUMERAL);
            foreach (var number in RegNumerals.Matches(s)
                                            .GetGenericEnumerator()
                                            .Select(m => m.Value)
                                            .OrderByDescending(n => n.Length))
            {
                var n = ConvertKanjiNumeral2Long(number, RegDivideGtThousand);
                var newValue = !string.IsNullOrEmpty(format) ? n.ToString(format) : n.ToString();
                s = s.Replace(number, newValue);
            }
            return s;
        }
        #endregion

        #endregion
    }
    #endregion
}
