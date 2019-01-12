using System.Text.RegularExpressions;
using System.Linq;
using hsb.Extensions;

namespace hsb.Utilities
{
    #region 【Static Class : AddressUtil】
    /// <summary>
    /// 住所関連ユーティリティ
    /// </summary>
    public static class AddressUtil
    {
        #region ■ Struct

        #region - NormalizeAddress : 正規化された住所
        /// <summary>
        /// 正規化された住所
        /// </summary>
        public struct NormalizeAddress
        {
            // 都道府県
            public string Prefecture { get; set; }
            // 市区町村
            public string City { get; set; }
            // 丁目・番地
            public string Address { get; set; }
            // 建物
            public string Building { get; set; }
            // 住所
            public string FullAddress
            {
                get { return $"{Prefecture}{City}{Address} {Building}"; }
            }
        }
        #endregion

        #endregion

        #region ■ Private Static Methods

        #region - GetPrefecture : 住所を都道府県とその他に分割する
        /// <summary>
        /// 住所を都道府県とその他に分割する
        /// </summary>
        /// <param name="address">住所</param>
        /// <returns>都道府県とその他のタプル</returns>
        private static (string prefecture, string other) GetPrefecture(string address)
        {
            var prefectures = string.Join("|", Constants.JAPANESE_PREFECTURS.Select(tp => tp.name));
            var m = Regex.Match(address.Trim(), $"^({prefectures})(.+)$");
            return (m.Success) ? (m.Groups[1].Value, m.Groups[2].Value) : ("", address.Trim());
        }
        #endregion

        #region - GetCity : 市区町村とその他に分割する
        /// <summary>
        /// 市区町村とその他に分割する
        /// </summary>
        /// <param name="address">住所</param>
        /// <returns>市区町村とその他のタプル</returns>
        private static (string city, string other) GetCity(string address)
        {
            var city = "";
            var pat = @"^(余市郡(仁木町|赤井川村|余市町)|余市町|柴田郡村田町|(武蔵|東)村山市|" +
                      @"[東西北]村山郡...?町|田村(市|郡..町)芳賀郡市貝町|(佐波郡)?玉村町|[羽大]村市|" +
                      @"(十日|大)町市|(中新川郡)?上市町|(野々|[四廿]日)市市|西八代郡市川三郷町|" +
                      @"神崎郡市川町|高市郡(高取町|明日香村)|(吉野郡)?下市町|(杵島郡)?大町町)(.+)$";
            var m1 = Regex.Match(address.Trim(), pat);
            if (m1.Success)
            {
                city = m1.Groups[1].Value;
                address = m1.Groups[12].Value;
            }
            var m2 = Regex.Match(address.Trim(), @"^(.+[市区町村])(.+)");
            return (m2.Success) ? ($"{city}{m2.Groups[1].Value}", m2.Groups[2].Value) : (city, address.Trim());
        }
        #endregion

        #region - NormalizeBuildingName : 建物の階数・部屋番号を正規化する
        /// <summary>
        /// 建物の階数・部屋番号を正規化する
        /// </summary>
        /// <param name="name">建物名</param>
        /// <returns>建物名</returns>
        private static string NormalizeBuildingName(string name)
        {
            var m = Regex.Match(name.Trim(), @"(.+?)(([\d〇一二三四五六七八九十百千万]+)(階|F|Ｆ|号|号室))$");
            if (m.Success)
            {
                var floor = KanjiNumeralUtil.Convert(m.Groups[3].Value);
                var suffix = m.Groups[4].Value;
                suffix = (suffix == "階" || suffix == "F" || suffix == "Ｆ") ?
                            "階" : "号室";
                return $"{m.Groups[1].Value.Trim()}{floor}{suffix}";
            }
            return name.Trim();
        }
        #endregion

        #region - GetAddress : 丁目・番地と建物に分割する
        /// <summary>
        /// 丁目・番地と建物に分割する
        /// </summary>
        /// <param name="address">住所</param>
        /// <returns>丁目・番地と建物のタプル</returns>
        private static (string addr, string other) GetAddress(string address)
        {
            // 「先頭は数字、途中は数字か繋ぎ文字1、最後は数字か繋ぎ文字2」を満たす正規表現
            var allNum = @"[\d一二三四五六七八九十百千万]+";
            var pat = $"(.*?)({allNum}({allNum}|丁目|丁|番地|番|号|-|‐|ー|−|の|東|西|南|北)*({allNum}|丁目|丁|番地|番|号))(.*)";
            var m = Regex.Match(address.Trim(), pat);
            if (m.Success)
            {
                var addr = string.Join("-",
                    Regex.Matches(m.Groups[2].Value, allNum)
                        .GetGenericEnumerator()
                        .Select(v => KanjiNumeralUtil.Convert(v.Value).ToString()));
                var building = NormalizeBuildingName(m.Groups[5].Value);
                return ($"{m.Groups[1].Value.Trim()}{addr}", building);
            }
            return ("", address.Trim());
        }
        #endregion


        #endregion

        #region ■ Static Methods

        #region - Normalize : 住所を正規化する
        /// <summary>
        /// 住所を正規化する
        /// </summary>
        /// <param name="addr">住所</param>
        /// <returns>正規化された住所</returns>
        public static NormalizeAddress Normalize(string addr)
        {
            var prefecture = "";
            var city = "";
            var address = "";
            var building = "";

            (prefecture, addr) = GetPrefecture(addr);
            (city, addr) = GetCity(addr);
            (address, building) = GetAddress(addr);

            return new NormalizeAddress
            {
                Prefecture = prefecture,
                City = city,
                Address = address,
                Building = building
            };
        }
        #endregion

        #endregion
    }
    #endregion
}