using WebService.Common.Helper.Interface;

namespace WebService.Common.Helper.Implementation
{
    public class CalendarHelper : ICalendarHelper
    {
        public enum ScriptOption
        {
            Roman,
            Devanagiri
        }
        public string GetEnglishDayOfWeek(int day)
        {
            return day switch
            {
                1 => "Sunday",
                2 => "Monday",
                3 => "Tuesday",
                4 => "Wednesday",
                5 => "Thursday",
                6 => "Friday",
                7 => "Saturday",
                _ => String.Empty
            };
        }

        public string GetNepaliDayOfWeek(int day)
        {
            return day switch
            {
                1 => "आइतबार",
                2 => "सोमबार",
                3 => "मंगलबार",
                4 => "बुधबार",
                5 => "बिहीबार",
                6 => "शुक्रबार",
                7 => "शनिबार",
                _ => String.Empty
            };
        }

        public string GetEnglishMonth(int month, ScriptOption option = ScriptOption.Roman)
        {
            return (month, option) switch
            {
                (1, ScriptOption.Roman) => "January",
                (1, ScriptOption.Devanagiri) => "जनवरी",
                (2, ScriptOption.Roman) => "February",
                (2, ScriptOption.Devanagiri) => "फरवरी",
                (3, ScriptOption.Roman) => "March",
                (3, ScriptOption.Devanagiri) => "मार्च",
                (4, ScriptOption.Roman) => "April",
                (4, ScriptOption.Devanagiri) => "अप्रैल",
                (5, ScriptOption.Roman) => "May",
                (5, ScriptOption.Devanagiri) => "मई",
                (6, ScriptOption.Roman) => "June",
                (6, ScriptOption.Devanagiri) => "जून",
                (7, ScriptOption.Roman) => "July",
                (7, ScriptOption.Devanagiri) => "जुलाई",
                (8, ScriptOption.Roman) => "August",
                (8, ScriptOption.Devanagiri) => "अगस्त",
                (9, ScriptOption.Roman) => "September",
                (9, ScriptOption.Devanagiri) => "सितंबर",
                (10, ScriptOption.Roman) => "October",
                (10, ScriptOption.Devanagiri) => "अक्टूबर",
                (11, ScriptOption.Roman) => "November",
                (11, ScriptOption.Devanagiri) => "नवंबर",
                (12, ScriptOption.Roman) => "December",
                (12, ScriptOption.Devanagiri) => "दिसंबर",
                _ => String.Empty
            };
        }

        public string GetNepaliMonth(int month, ScriptOption option = ScriptOption.Devanagiri)
        {
            return (month, option) switch
            {
                (1, ScriptOption.Roman) => "Baisakh",
                (1, ScriptOption.Devanagiri) => "वैशाख",
                (2, ScriptOption.Roman) => "Jestha",
                (2, ScriptOption.Devanagiri) => "जेठ",
                (3, ScriptOption.Roman) => "Ashad",
                (3, ScriptOption.Devanagiri) => "असार",
                (4, ScriptOption.Roman) => "Shrawan",
                (4, ScriptOption.Devanagiri) => "श्रावण",
                (5, ScriptOption.Roman) => "Bhadra",
                (5, ScriptOption.Devanagiri) => "भाद्र",
                (6, ScriptOption.Roman) => "Ashwin",
                (6, ScriptOption.Devanagiri) => "आश्विन",
                (7, ScriptOption.Roman) => "Kartik",
                (7, ScriptOption.Devanagiri) => "कार्तिक",
                (8, ScriptOption.Roman) => "Mangsir",
                (8, ScriptOption.Devanagiri) => "मंसिर",
                (9, ScriptOption.Roman) => "Poush",
                (9, ScriptOption.Devanagiri) => "पुष",
                (10, ScriptOption.Roman) => "Magh",
                (10, ScriptOption.Devanagiri) => "माघ",
                (11, ScriptOption.Roman) => "Falgun",
                (11, ScriptOption.Devanagiri) => "फाल्गुन",
                (12, ScriptOption.Roman) => "Chaitra",
                (12, ScriptOption.Devanagiri) => "चैत्र",
                _ => String.Empty
            };
        }
    }
}
