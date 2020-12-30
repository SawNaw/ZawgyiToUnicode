using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ZawgyiToUnicode.TextConverter
{
    /// <summary>
    /// Provides methods to convert non-Unicode compliant Zawgyi text to Unicode-compliant Burmese text, and vice-versa.
    /// </summary>
    public static class Convert
    {
        private static readonly Dictionary<string, string> UnicodeToZawgyiConversionRules;
        private static readonly Dictionary<string, string> ZawgyiToUnicodeConversionRules;

        static Convert()
        {
            UnicodeToZawgyiConversionRules = new Dictionary<string, string>();
            ZawgyiToUnicodeConversionRules = new Dictionary<string, string>();

            AddConversionRules();
        }

        /// <summary>
        /// Returns the Zawgyi equivalent of the given Unicode-compliant string.
        /// </summary>
        /// <param name="unicodeText">The Unicode-compliant string to convert to Zawgyi text.</param>
        /// <returns>The Zawgyi equivalent of the given Unicode-compliant string.</returns>
        public static string ToZawgyi(string unicodeText)
        {
            return ConvertUsingRules(UnicodeToZawgyiConversionRules, unicodeText);
        }

        /// <summary>
        /// Returns the Unicode-compliant equivalent of the given Zawgyi string.
        /// </summary>
        /// <param name="zawgyiText">The Zawgyi string to convert to Unicode-compliant text.</param>
        /// <returns>The Unicode-compliant equivalent of the given Zawgyi string</returns>
        public static string ToUnicode(string zawgyiText)
        {
            return ConvertUsingRules(ZawgyiToUnicodeConversionRules, zawgyiText);
        }

        private static void AddConversionRules()
        {
            AddZawgyiToUnicodeConversionRules();
            AddUnicodeToZawgyiConversionRules();
        }

        private static void AddUnicodeToZawgyiConversionRules()
        {
            UnicodeToZawgyiConversionRules.Add("\u1004\u103a\u1039", "\u1064");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1010\u103d", "\u1096");
            UnicodeToZawgyiConversionRules.Add("\u102b\u103a", "\u105a");
            UnicodeToZawgyiConversionRules.Add("\u102d\u1036", "\u108e");
            UnicodeToZawgyiConversionRules.Add("\u104e\u1004\u103a\u1038", "\u104e");
            UnicodeToZawgyiConversionRules.Add("[\u1025\u1009](?=\u1039)", "\u106a");
            UnicodeToZawgyiConversionRules.Add("\u1009(?=[\u102f\u1030])", "\u1025");
            UnicodeToZawgyiConversionRules.Add("[\u1025\u1009](?=[\u1037]?[\u103a])", "\u1025");
            UnicodeToZawgyiConversionRules.Add("\u100a(?=[\u1039\u103d])", "\u106b");
            UnicodeToZawgyiConversionRules.Add("(\u1039[\u1000-\u1021])(\u102D)0,1}\u102f", "$1$2\u1033");
            UnicodeToZawgyiConversionRules.Add("(\u1039[\u1000-\u1021])\u1030", "$1\u1034");
            UnicodeToZawgyiConversionRules.Add("\u1014(?=[\u102d\u102e\u102f\u103A]?[\u1030\u103d\u103e\u102f\u1039])", "\u108f");
            UnicodeToZawgyiConversionRules.Add("\u1014(?=\u103A\u102F )", "\u108f");
            UnicodeToZawgyiConversionRules.Add("\u1014\u103c", "\u108f\u103c");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1000", "\u1060");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1001", "\u1061");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1002", "\u1062");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1003", "\u1063");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1005", "\u1065");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1006", "\u1066");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1007", "\u1068");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1008", "\u1069");
            UnicodeToZawgyiConversionRules.Add("\u1039\u100b", "\u106c");
            UnicodeToZawgyiConversionRules.Add("\u100b\u1039\u100c", "\u1092");
            UnicodeToZawgyiConversionRules.Add("\u1039\u100c", "\u106d");
            UnicodeToZawgyiConversionRules.Add("\u100d\u1039\u100d", "\u106e");
            UnicodeToZawgyiConversionRules.Add("\u100d\u1039\u100e", "\u106f");
            UnicodeToZawgyiConversionRules.Add("\u1039\u100f", "\u1070");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1010", "\u1071");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1011", "\u1073");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1012", "\u1075");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1013", "\u1076");
            UnicodeToZawgyiConversionRules.Add("\u1039[\u1014\u108f]", "\u1077");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1015", "\u1078");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1016", "\u1079");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1017", "\u107a");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1018", "\u107b");
            UnicodeToZawgyiConversionRules.Add("\u1039\u1019", "\u107c");
            UnicodeToZawgyiConversionRules.Add("\u1039\u101c", "\u1085");
            UnicodeToZawgyiConversionRules.Add("\u103f", "\u1086");
            UnicodeToZawgyiConversionRules.Add("\u103d\u103e", "\u108a");
            UnicodeToZawgyiConversionRules.Add("(\u1064)([\u1000-\u1021])([\u103b\u103c]?)\u102d", "$2$3\u108b");
            UnicodeToZawgyiConversionRules.Add("(\u1064)([\u1000-\u1021])([\u103b\u103c]?)\u102e", "$2$3\u108c");
            UnicodeToZawgyiConversionRules.Add("(\u1064)([\u1000-\u1021])([\u103b\u103c]?)\u1036", "$2$3\u108d");
            UnicodeToZawgyiConversionRules.Add("(\u1064)([\u1000-\u1021\u1040-\u1049])([\u103b\u103c]?)([\u1031]?)", "$2$3$4$1");
            UnicodeToZawgyiConversionRules.Add("\u101b(?=([\u102d\u102e]?)[\u102f\u1030\u103d\u108a])", "\u1090");
            UnicodeToZawgyiConversionRules.Add("\u100f\u1039\u100d", "\u1091");
            UnicodeToZawgyiConversionRules.Add("\u100b\u1039\u100b", "\u1097");
            UnicodeToZawgyiConversionRules.Add("([\u1000-\u1021\u108f\u1029\u106e\u106f\u1086\u1090\u1091\u1092\u1097])([\u1060-\u1069\u106c\u106d\u1070-\u107c\u1085\u108a])?([\u103b-\u103e]*)?\u1031", "\u1031$1$2$3");
            UnicodeToZawgyiConversionRules.Add("\u103c\u103e", "\u103c\u1087");
            UnicodeToZawgyiConversionRules.Add("([\u1000-\u1021\u108f\u1029])([\u1060-\u1069\u106c\u106d\u1070-\u107c\u1085])?(\u103c)", "$3$1$2");
            UnicodeToZawgyiConversionRules.Add("\u103a", "\u1039");
            UnicodeToZawgyiConversionRules.Add("\u103b", "\u103a");
            UnicodeToZawgyiConversionRules.Add("\u103c", "\u103b");
            UnicodeToZawgyiConversionRules.Add("\u103d", "\u103c");
            UnicodeToZawgyiConversionRules.Add("\u103e", "\u103d");
            UnicodeToZawgyiConversionRules.Add("([^\u103a\u100a])\u103d([\u102d\u102e]?)\u102f", "$1\u1088$2");
            UnicodeToZawgyiConversionRules.Add("([\u101b\u103a\u103c\u108a\u1088\u1090])([\u1030\u103d])?([\u1032\u1036\u1039\u102d\u102e\u108b\u108c\u108d\u108e]?)(\u102f)?\u1037", "$1$2$3$4\u1095");
            UnicodeToZawgyiConversionRules.Add("([\u102f\u1014\u1030\u103d])([\u1032\u1036\u1039\u102d\u102e\u108b\u108c\u108d\u108e]?)\u1037", "$1$2\u1094");
            UnicodeToZawgyiConversionRules.Add("([\u103b])([\u1000-\u1021])([\u1087]?)([\u1036\u102d\u102e\u108b\u108c\u108d\u108e]?)\u102f", "$1$2$3$4\u1033");
            UnicodeToZawgyiConversionRules.Add("([\u103b])([\u1000-\u1021])([\u1087]?)([\u1036\u102d\u102e\u108b\u108c\u108d\u108e]?)\u1030", "$1$2$3$4\u1034");
            UnicodeToZawgyiConversionRules.Add("([\u103a\u103c\u100a\u1008\u100b\u100c\u100d\u1020\u1025])([\u103d]?)([\u1036\u102d\u102e\u108b\u108c\u108d\u108e]?)\u102f", "$1$2$3\u1033");
            UnicodeToZawgyiConversionRules.Add("([\u103a\u103c\u100a\u1008\u100b\u100c\u100d\u1020\u1025])(\u103d?)([\u1036\u102d\u102e\u108b\u108c\u108d\u108e]?)\u1030", "$1$2$3\u1034");
            UnicodeToZawgyiConversionRules.Add("([\u100a\u1020\u1009])\u103d", "$1\u1087");
            UnicodeToZawgyiConversionRules.Add("\u103d\u1030", "\u1089");
            UnicodeToZawgyiConversionRules.Add("\u103b([\u1000\u1003\u1006\u100f\u1010\u1011\u1018\u101a\u101c\u101a\u101e\u101f])", "\u107e$1");
            UnicodeToZawgyiConversionRules.Add("\u107e([\u1000\u1003\u1006\u100f\u1010\u1011\u1018\u101a\u101c\u101a\u101e\u101f])([\u103c\u108a])([\u1032\u1036\u102d\u102e\u108b\u108c\u108d\u108e])", "\u1084$1$2$3");
            UnicodeToZawgyiConversionRules.Add("\u107e([\u1000\u1003\u1006\u100f\u1010\u1011\u1018\u101a\u101c\u101a\u101e\u101f])([\u103c\u108a])", "\u1082$1$2");
            UnicodeToZawgyiConversionRules.Add("\u107e([\u1000\u1003\u1006\u100f\u1010\u1011\u1018\u101a\u101c\u101a\u101e\u101f])([\u1033\u1034]?)([\u1032\u1036\u102d\u102e\u108b\u108c\u108d\u108e])", "\u1080$1$2$3");
            UnicodeToZawgyiConversionRules.Add("\u103b([\u1000-\u1021])([\u103c\u108a])([\u1032\u1036\u102d\u102e\u108b\u108c\u108d\u108e])", "\u1083$1$2$3");
            UnicodeToZawgyiConversionRules.Add("\u103b([\u1000-\u1021])([\u103c\u108a])", "\u1081$1$2");
            UnicodeToZawgyiConversionRules.Add("\u103b([\u1000-\u1021])([\u1033\u1034]?)([\u1032\u1036\u102d\u102e\u108b\u108c\u108d\u108e])", "\u107f$1$2$3");
            UnicodeToZawgyiConversionRules.Add("\u103a\u103d", "\u103d\u103a");
            UnicodeToZawgyiConversionRules.Add("\u103a([\u103c\u108a])", "$1\u107d");
            UnicodeToZawgyiConversionRules.Add("([\u1033\u1034])(\u1036?)\u1094", "$1$2\u1095");
            UnicodeToZawgyiConversionRules.Add("\u108F\u1071", "\u108F\u1072");
            UnicodeToZawgyiConversionRules.Add("([\u1000-\u1021])([\u107B\u1066])\u102C", "$1\u102C$2");
            UnicodeToZawgyiConversionRules.Add("\u102C([\u107B\u1066])\u1037", "\u102C$1\u1094");
            UnicodeToZawgyiConversionRules.Add("\u1047((?=[\u1000-\u1021]\u1039)|(?=[\u102c-\u1030\u1032\u1036-\u1038\u103c\u103d]))", "\u101b");
        }

        private static void AddZawgyiToUnicodeConversionRules()
        {
            ZawgyiToUnicodeConversionRules.Add("([\u102D\u102E\u103D\u102F\u1037\u1095])\\1+", "$1");
            ZawgyiToUnicodeConversionRules.Add("\u200B", "");
            ZawgyiToUnicodeConversionRules.Add("\u103d\u103c", "\u108a");
            ZawgyiToUnicodeConversionRules.Add("(\u103d|\u1087)", "\u103e");
            ZawgyiToUnicodeConversionRules.Add("\u103c", "\u103d");
            ZawgyiToUnicodeConversionRules.Add("(\u103b|\u107e|\u107f|\u1080|\u1081|\u1082|\u1083|\u1084)", "\u103c");
            ZawgyiToUnicodeConversionRules.Add("(\u103a|\u107d)", "\u103b");
            ZawgyiToUnicodeConversionRules.Add("\u1039", "\u103a");
            ZawgyiToUnicodeConversionRules.Add("(\u1066|\u1067)", "\u1039\u1006");
            ZawgyiToUnicodeConversionRules.Add("\u106a", "\u1009");
            ZawgyiToUnicodeConversionRules.Add("\u106b", "\u100a");
            ZawgyiToUnicodeConversionRules.Add("\u106c", "\u1039\u100b");
            ZawgyiToUnicodeConversionRules.Add("\u106d", "\u1039\u100c");
            ZawgyiToUnicodeConversionRules.Add("\u106e", "\u100d\u1039\u100d");
            ZawgyiToUnicodeConversionRules.Add("\u106f", "\u100d\u1039\u100e");
            ZawgyiToUnicodeConversionRules.Add("\u1070", "\u1039\u100f");
            ZawgyiToUnicodeConversionRules.Add("(\u1071|\u1072)", "\u1039\u1010");
            ZawgyiToUnicodeConversionRules.Add("\u1060", "\u1039\u1000");
            ZawgyiToUnicodeConversionRules.Add("\u1061", "\u1039\u1001");
            ZawgyiToUnicodeConversionRules.Add("\u1062", "\u1039\u1002");
            ZawgyiToUnicodeConversionRules.Add("\u1063", "\u1039\u1003");
            ZawgyiToUnicodeConversionRules.Add("\u1065", "\u1039\u1005");
            ZawgyiToUnicodeConversionRules.Add("\u1068", "\u1039\u1007");
            ZawgyiToUnicodeConversionRules.Add("\u1069", "\u1039\u1008");
            ZawgyiToUnicodeConversionRules.Add("(\u1073|\u1074)", "\u1039\u1011");
            ZawgyiToUnicodeConversionRules.Add("\u1075", "\u1039\u1012");
            ZawgyiToUnicodeConversionRules.Add("\u1076", "\u1039\u1013");
            ZawgyiToUnicodeConversionRules.Add("\u1077", "\u1039\u1014");
            ZawgyiToUnicodeConversionRules.Add("\u1078", "\u1039\u1015");
            ZawgyiToUnicodeConversionRules.Add("\u1079", "\u1039\u1016");
            ZawgyiToUnicodeConversionRules.Add("\u107a", "\u1039\u1017");
            ZawgyiToUnicodeConversionRules.Add("\u107c", "\u1039\u1019");
            ZawgyiToUnicodeConversionRules.Add("\u1085", "\u1039\u101c");
            ZawgyiToUnicodeConversionRules.Add("\u1033", "\u102f");
            ZawgyiToUnicodeConversionRules.Add("\u1034", "\u1030");
            ZawgyiToUnicodeConversionRules.Add("\u103f", "\u1030");
            ZawgyiToUnicodeConversionRules.Add("\u1086", "\u103f");
            ZawgyiToUnicodeConversionRules.Add("\u1036\u1088", "\u1088\u1036");
            ZawgyiToUnicodeConversionRules.Add("\u1088", "\u103e\u102f");
            ZawgyiToUnicodeConversionRules.Add("\u1089", "\u103e\u1030");
            ZawgyiToUnicodeConversionRules.Add("\u108a", "\u103d\u103e");
            ZawgyiToUnicodeConversionRules.Add("\u103B\u1064", "\u1064\u103B");
            ZawgyiToUnicodeConversionRules.Add("\u103c([\u1000-\u1021])(\u1064|\u108b)", "$1\u103c$2");
            ZawgyiToUnicodeConversionRules.Add("(\u1031)?([\u1000-\u1021\u1040-\u1049])(\u103c)?\u1064", "\u1004\u103a\u1039$1$2$3");
            ZawgyiToUnicodeConversionRules.Add("(\u1031)?([\u1000-\u1021])(\u103b|\u103c)?\u108b", "\u1004\u103a\u1039$1$2$3\u102d");
            ZawgyiToUnicodeConversionRules.Add("(\u1031)?([\u1000-\u1021])(\u103b)?\u108c", "\u1004\u103a\u1039$1$2$3\u102e");
            ZawgyiToUnicodeConversionRules.Add("(\u1031)?([\u1000-\u1021])(\u103b)?\u108d", "\u1004\u103a\u1039$1$2$3\u1036");
            ZawgyiToUnicodeConversionRules.Add("\u108e", "\u102d\u1036");
            ZawgyiToUnicodeConversionRules.Add("\u108f", "\u1014");
            ZawgyiToUnicodeConversionRules.Add("\u1090", "\u101b");
            ZawgyiToUnicodeConversionRules.Add("\u1091", "\u100f\u1039\u100d");
            ZawgyiToUnicodeConversionRules.Add("\u1092", "\u100b\u1039\u100c");
            ZawgyiToUnicodeConversionRules.Add("\u1019\u102c(\u107b|\u1093)", "\u1019\u1039\u1018\u102c");
            ZawgyiToUnicodeConversionRules.Add("(\u107b|\u1093)", "\u1039\u1018");
            ZawgyiToUnicodeConversionRules.Add("(\u1094|\u1095)", "\u1037");
            ZawgyiToUnicodeConversionRules.Add("([\u1000-\u1021])\u1037\u1032", "$1\u1032\u1037");
            ZawgyiToUnicodeConversionRules.Add("\u1096", "\u1039\u1010\u103d");
            ZawgyiToUnicodeConversionRules.Add("\u1097", "\u100b\u1039\u100b");
            ZawgyiToUnicodeConversionRules.Add("\u103c([\u1000-\u1021])([\u1000-\u1021])?", "$1\u103c$2");
            ZawgyiToUnicodeConversionRules.Add("([\u1000-\u1021])\u103c\u103a", "\u103c$1\u103a");
            ZawgyiToUnicodeConversionRules.Add("\u1047(?=[\u102c-\u1030\u1032\u1036-\u1038\u103d\u1038])", "\u101b");
            ZawgyiToUnicodeConversionRules.Add("\u1031\u1047", "\u1031\u101b");
            ZawgyiToUnicodeConversionRules.Add("\u1040(\u102e|\u102f|\u102d\u102f|\u1030|\u1036|\u103d|\u103e)", "\u101d$1");
            ZawgyiToUnicodeConversionRules.Add("([^\u1040\u1041\u1042\u1043\u1044\u1045\u1046\u1047\u1048\u1049])\u1040\u102b", "$1\u101d\u102b");
            ZawgyiToUnicodeConversionRules.Add("([\u1040\u1041\u1042\u1043\u1044\u1045\u1046\u1047\u1048\u1049])\u1040\u102b(?!\u1038)", "$1\u101d\u102b");
            ZawgyiToUnicodeConversionRules.Add("^\u1040(?=\u102b)", "\u101d");
            ZawgyiToUnicodeConversionRules.Add("\u1040\u102d(?!\u0020?/)", "\u101d\u102d");
            ZawgyiToUnicodeConversionRules.Add("([^\u1040-\u1049])\u1040([^\u1040-\u1049\u0020]|[\u104a\u104b])", "$1\u101d$2");
            ZawgyiToUnicodeConversionRules.Add("([^\u1040-\u1049])\u1040(?=[\\f\\n\\r])", "$1\u101d");
            ZawgyiToUnicodeConversionRules.Add("([^\u1040-\u1049])\u1040$", "$1\u101d");
            ZawgyiToUnicodeConversionRules.Add("\u1031([\u1000-\u1021\u103f])(\u103e)?(\u103b)?", "$1$2$3\u1031");
            ZawgyiToUnicodeConversionRules.Add("([\u1000-\u1021])\u1031([\u103b\u103c\u103d\u103e]+)", "$1$2\u1031");
            ZawgyiToUnicodeConversionRules.Add("\u1032\u103d", "\u103d\u1032");
            ZawgyiToUnicodeConversionRules.Add("([\u102d\u102e])\u103b", "\u103b$1");
            ZawgyiToUnicodeConversionRules.Add("\u103d\u103b", "\u103b\u103d");
            ZawgyiToUnicodeConversionRules.Add("\u103a\u1037", "\u1037\u103a");
            ZawgyiToUnicodeConversionRules.Add("\u102f(\u102d|\u102e|\u1036|\u1037)\u102f", "\u102f$1");
            ZawgyiToUnicodeConversionRules.Add("(\u102f|\u1030)(\u102d|\u102e)", "$2$1");
            ZawgyiToUnicodeConversionRules.Add("(\u103e)(\u103b|\u103c)", "$2$1");
            ZawgyiToUnicodeConversionRules.Add("\u1025(?=[\u1037]?[\u103a\u102c])", "\u1009");
            ZawgyiToUnicodeConversionRules.Add("\u1025\u102e", "\u1026");
            ZawgyiToUnicodeConversionRules.Add("\u1005\u103b", "\u1008");
            ZawgyiToUnicodeConversionRules.Add("\u1036(\u102f|\u1030)", "$1\u1036");
            ZawgyiToUnicodeConversionRules.Add("\u1031\u1037\u103e", "\u103e\u1031\u1037");
            ZawgyiToUnicodeConversionRules.Add("\u1031\u103e\u102c", "\u103e\u1031\u102c");
            ZawgyiToUnicodeConversionRules.Add("\u105a", "\u102b\u103a");
            ZawgyiToUnicodeConversionRules.Add("\u1031\u103b\u103e", "\u103b\u103e\u1031");
            ZawgyiToUnicodeConversionRules.Add("(\u102d|\u102e)(\u103d|\u103e)", "$2$1");
            ZawgyiToUnicodeConversionRules.Add("\u102c\u1039([\u1000-\u1021])", "\u1039$1\u102c");
            ZawgyiToUnicodeConversionRules.Add("\u1039\u103c\u103a\u1039([\u1000-\u1021])", "\u103a\u1039$1\u103c");
            ZawgyiToUnicodeConversionRules.Add("\u103c\u1039([\u1000-\u1021])", "\u1039$1\u103c");
            ZawgyiToUnicodeConversionRules.Add("\u1036\u1039([\u1000-\u1021])", "\u1039$1\u1036");
            ZawgyiToUnicodeConversionRules.Add("\u104e", "\u104e\u1004\u103a\u1038");
            ZawgyiToUnicodeConversionRules.Add("\u1040(\u102b|\u102c|\u1036)", "\u101d$1");
            ZawgyiToUnicodeConversionRules.Add("\u1025\u1039", "\u1009\u1039");
            ZawgyiToUnicodeConversionRules.Add("([\u1000-\u1021])\u103c\u1031\u103d", "$1\u103c\u103d\u1031");
            ZawgyiToUnicodeConversionRules.Add("([\u1000-\u1021])\u103b\u1031\u103d(\u103e)?", "$1\u103b\u103d$2\u1031");
            ZawgyiToUnicodeConversionRules.Add("([\u1000-\u1021])\u103d\u1031\u103b", "$1\u103b\u103d\u1031");
            ZawgyiToUnicodeConversionRules.Add("([\u1000-\u1021])\u1031(\u1039[\u1000-\u1021])", "$1$2\u1031");
            ZawgyiToUnicodeConversionRules.Add("\u1038\u103a", "\u103a\u1038");
            ZawgyiToUnicodeConversionRules.Add("\u102d\u103a|\u103a\u102d", "\u102d");
            ZawgyiToUnicodeConversionRules.Add("\u102d\u102f\u103a", "\u102d\u102f");
            ZawgyiToUnicodeConversionRules.Add("\u0020\u1037", "\u1037");
            ZawgyiToUnicodeConversionRules.Add("\u1037\u1036", "\u1036\u1037");
            ZawgyiToUnicodeConversionRules.Add("[\u102d]+", "\u102d");
            ZawgyiToUnicodeConversionRules.Add("[\u103a]+", "\u103a");
            ZawgyiToUnicodeConversionRules.Add("[\u103d]+", "\u103d");
            ZawgyiToUnicodeConversionRules.Add("[\u1037]+", "\u1037");
            ZawgyiToUnicodeConversionRules.Add("[\u102e]+", "\u102e");
            ZawgyiToUnicodeConversionRules.Add("\u102d\u102e|\u102e\u102d", "\u102e");
            ZawgyiToUnicodeConversionRules.Add("\u102f\u102d", "\u102d\u102f");
            ZawgyiToUnicodeConversionRules.Add("\u1037\u1037", "\u1037");
            ZawgyiToUnicodeConversionRules.Add("\u1032\u1032", "\u1032");
            ZawgyiToUnicodeConversionRules.Add("\u1044\u1004\u103a\u1038", "\u104E\u1004\u103a\u1038");
            ZawgyiToUnicodeConversionRules.Add("([\u102d\u102e])\u1039([\u1000-\u1021])", "\u1039$2$1");
            ZawgyiToUnicodeConversionRules.Add("(\u103c\u1031)\u1039([\u1000-\u1021])", "\u1039$2$1");
            ZawgyiToUnicodeConversionRules.Add("\u1036\u103d", "\u103d\u1036");
            ZawgyiToUnicodeConversionRules.Add("\u1047((?=[\u1000-\u1021]\u103a)|(?=[\u102c-\u1030\u1032\u1036-\u1038\u103d\u103e]))", "\u101b");
        }

        private static string ConvertUsingRules(IReadOnlyDictionary<string, string> conversionRules, string input)
        {
            foreach (var rule in conversionRules)
            {
                Regex rgx = new Regex(rule.Key);
                input = rgx.Replace(input, rule.Value);
            }

            return input;
        }
    }
}

