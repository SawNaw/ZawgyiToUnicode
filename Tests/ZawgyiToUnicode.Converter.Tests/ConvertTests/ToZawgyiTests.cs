using NUnit.Framework;

namespace ZawgyiToUnicode.Converter.Tests.ConvertTests;

public class ToZawgyiTests
{
    [TestCase("ကနဦး သိန်း၂၅၀ ဖြင့် ဟိုတယ်ပိုင်ရှင်ဖြစ်နိုင်ပါပြီ", "ကနဦး သိန္း၂၅၀ ျဖင့္ ဟိုတယ္ပိုင္ရွင္ျဖစ္ႏိုင္ပါၿပီ")]
    [TestCase("ခိုင်မာတဲ့ ရင်းနှီးမြုပ်နှံမှုကောင်း တစ်ခုကို ပိုင်ဆိုင် နိုင်မယ်", "ခိုင္မာတဲ့ ရင္းႏွီးျမဳပ္ႏွံမႈေကာင္း တစ္ခုကို ပိုင္ဆိုင္ ႏိုင္မယ္")]
    [TestCase("Bank နှင့် အရစ်ကျ ၁၀ နှစ်မှ ၁၅ နှစ်အထိ ယူလို့ရတယ်", "Bank ႏွင့္ အရစ္က် ၁၀ ႏွစ္မွ ၁၅ ႏွစ္အထိ ယူလို႔ရတယ္")]
    [TestCase("သီဟိုဠ်မှ ဉာဏ်ကြီးရှင်သည် အာယုဝဍ္ဎနဆေးညွှန်းစာကို ဇလွန်ဈေးဘေး ဗာဒံပင်ထက် အဓိဋ္ဌာန်လျက် ဂဃနဏဖတ်ခဲ့သည်။", "သီဟိုဠ္မွ ဉာဏ္ႀကီးရွင္သည္ အာယုဝၯနေဆးၫႊန္းစာကို ဇလြန္ေဈးေဘး ဗာဒံပင္ထက္ အဓိ႒ာန္လ်က္ ဂဃနဏဖတ္ခဲ့သည္။")]
    public void SimpleUnicodeStrings_ConvertToZawgyiCorrectly(string unicodeText, string expectedZawgyiText)
    {
        Assert.That(Convert.ToZawgyi(unicodeText), Is.EqualTo(expectedZawgyiText));
    }
}
