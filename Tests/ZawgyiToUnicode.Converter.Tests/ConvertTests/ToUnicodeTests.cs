using NUnit.Framework;
using ZawgyiToUnicode.StringConverter;

namespace ZawgyiToUnicode.Converter.Tests.ConvertTests;
public class ToUnicodeTests
{
    [TestCase("တပ်မက်မှု ‘တဏှာ’ ချုပ်ရ၏၊ တပ်မက်မှု ‘တဏှာ’ ချုပ်ခြင်းကြောင့် ပြင်း စွာ စွဲလမ်းမှု ‘ဥပါဒါန်’ ချုပ်ရ၏၊ ပြင်းစွာ စွဲလမ်းမှု ‘ဥပါဒါန်’ ချုပ်ခြင်းကြောင့် ဘဝ ချုပ်ရ၏၊ ဘဝ ချုပ်ခြင်း ကြောင့် ပဋိသန္ဓေနေမှု ‘ဇာတိ’ ချုပ်ရ၏၊ ဇာတိ ချုပ်ခြင်းကြောင့် အိုမှု ‘ဇရာ’၊ သေမှု ‘မရဏ’၊ စိုးရိမ်မှု",
          "တပ္မက္မႈ ‘တဏွာ’ ခ်ဳပ္ရ၏၊ တပ္မက္မႈ ‘တဏွာ’ ခ်ဳပ္ျခင္းေၾကာင့္ ျပင္း စြာ စြဲလမ္းမႈ ‘ဥပါဒါန္’ ခ်ဳပ္ရ၏၊ ျပင္းစြာ စြဲလမ္းမႈ ‘ဥပါဒါန္’ ခ်ဳပ္ျခင္းေၾကာင့္ ဘဝ ခ်ဳပ္ရ၏၊ ဘဝ ခ်ဳပ္ျခင္း ေၾကာင့္ ပဋိသေႏၶေနမႈ ‘ဇာတိ’ ခ်ဳပ္ရ၏၊ ဇာတိ ခ်ဳပ္ျခင္းေၾကာင့္ အိုမႈ ‘ဇရာ’၊ ေသမႈ ‘မရဏ’၊ စိုးရိမ္မႈ")]
    [TestCase("ရဟန်းတို့ ဤတရားကို ပဋိစ္စသမုပ္ပါဒ်ဟု ဆိုအပ်၏။", "ရဟန္းတို႔ ဤတရားကို ပဋိစၥသမုပၸါဒ္ဟု ဆိုအပ္၏။")]
    public void ComplexZawgyiStrings_ConvertToUnicodeCorrectly(string unicodeText, string expectedZawgyiText)
    {
        Assert.That(Convert.ToZawgyi(unicodeText), Is.EqualTo(expectedZawgyiText));
    }
}
