using static WebService.Common.Helper.Implementation.CalendarHelper;

namespace WebService.Common.Helper.Interface
{
    public interface ICalendarHelper
    {
        string GetEnglishDayOfWeek(int day);
        string GetNepaliDayOfWeek(int day);
        string GetEnglishMonth(int month, ScriptOption option);
        string GetNepaliMonth(int month, ScriptOption option);
    }
}
