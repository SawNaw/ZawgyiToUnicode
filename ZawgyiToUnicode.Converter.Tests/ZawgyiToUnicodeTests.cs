﻿using NUnit.Framework;

namespace ZawgyiToUnicode.Converter.Tests.ZawgyiToUnicode
{
    [TestFixture]
    public class ZawgyiToUnicodeTests
    {
        [TestCase("ကနဦး သိန္း၂၅၀ ျဖင့္ ဟိုတယ္ပိုင္ရွင္ျဖစ္နိုင္ပါၿပီ", "ကနဦး သိန်း၂၅၀ ဖြင့် ဟိုတယ်ပိုင်ရှင်ဖြစ်နိုင်ပါပြီ")]
        [TestCase("ခိုင္မာတဲ့ ရင္းႏွီးျမဳပ္ႏွံမွုေကာင္း တစ္ခုကို ပိုင္ဆိုင္ နိုင္မယ္", "ခိုင်မာတဲ့ ရင်းနှီးမြုပ်နှံမှုကောင်း တစ်ခုကို ပိုင်ဆိုင် နိုင်မယ်")]
        [TestCase("Bank ႏွင့္ အရစ္က် ၁၀ ႏွစ္မွ ၁၅ ႏွစ္အထိ ယူလို့ရတယ္", "Bank နှင့် အရစ်ကျ ၁၀ နှစ်မှ ၁၅ နှစ်အထိ ယူလို့ရတယ်")]
        [TestCase("သီဟိုဠ္မွ ဉာဏ္ႀကီးရွင္သည္ အာယုဝၯနေဆးၫႊန္းစာကို ဇလြန္ေဈးေဘး ဗာဒံပင္ထက္ အဓိ႒ာန္လ်က္ ဂဃနဏဖတ္ခဲ့သည္။", "သီဟိုဠ်မှ ဉာဏ်ကြီးရှင်သည် အာယုဝဍ္ဎနဆေးညွှန်းစာကို ဇလွန်ဈေးဘေး ဗာဒံပင်ထက် အဓိဋ္ဌာန်လျက် ဂဃနဏဖတ်ခဲ့သည်။")]
        public void SimpleZawgyiStrings_ConvertToUnicodeCorrectly(string zawgyiText, string expectedUnicodeText)
        {
            Assert.That(Convert.ToUnicode(zawgyiText), Is.EqualTo(expectedUnicodeText));
        }

        [TestCase("တပ္မက္မႈ ‘တဏွာ’ ခ်ဳပ္ရ၏၊ တပ္မက္မႈ ‘တဏွာ’ ခ်ဳပ္ျခင္းေၾကာင့္ ျပင္း စြာ စြဲလမ္းမႈ ‘ဥပါဒါန္’ ခ်ဳပ္ရ၏၊ ျပင္းစြာ စြဲလမ္းမႈ ‘ဥပါဒါန္’ ခ်ဳပ္ျခင္းေၾကာင့္ ဘဝ ခ်ဳပ္ရ၏၊ ဘဝ ခ်ဳပ္ျခင္း ေၾကာင့္ ပဋိသေႏၶေနမႈ ‘ဇာတိ’ ခ်ဳပ္ရ၏၊ ဇာတိ ခ်ဳပ္ျခင္းေၾကာင့္ အိုမႈ ‘ဇရာ’၊ ေသမႈ ‘မရဏ’၊ စိုးရိမ္မႈ",
            "တပ်မက်မှု ‘တဏှာ’ ချုပ်ရ၏၊ တပ်မက်မှု ‘တဏှာ’ ချုပ်ခြင်းကြောင့် ပြင်း စွာ စွဲလမ်းမှု ‘ဥပါဒါန်’ ချုပ်ရ၏၊ ပြင်းစွာ စွဲလမ်းမှု ‘ဥပါဒါန်’ ချုပ်ခြင်းကြောင့် ဘဝ ချုပ်ရ၏၊ ဘဝ ချုပ်ခြင်း ကြောင့် ပဋိသန္ဓေနေမှု ‘ဇာတိ’ ချုပ်ရ၏၊ ဇာတိ ချုပ်ခြင်းကြောင့် အိုမှု ‘ဇရာ’၊ သေမှု ‘မရဏ’၊ စိုးရိမ်မှု")]
        [TestCase("ရဟန္းတို႔ ဤတရားကို ပဋိစၥသမုပၸါဒ္ဟု ဆိုအပ္၏။", "ရဟန်းတို့ ဤတရားကို ပဋိစ္စသမုပ္ပါဒ်ဟု ဆိုအပ်၏။")]
        public void ComplexZawgyiStrings_ConvertToUnicodeCorrectly(string zawgyiText, string expectedUnicodeText)
        {
            Assert.That(Convert.ToUnicode(zawgyiText), Is.EqualTo(expectedUnicodeText));
        }
    }
}
