using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Types
{
    #region 【Enum : DatePart】
    /// <summary>
    /// 日時部位
    /// </summary>
    public enum DatePart { Year, Month, Day, Hour, Minute, Second, Milisecond }
    #endregion

    #region 【Enum : MapStringFlags】
    /// <summary>
    /// LCMapStringWに使用するフラグ定数
    /// </summary>
    public enum MapStringFlags : uint
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


}
