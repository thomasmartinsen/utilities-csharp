using System.Globalization;

namespace DateTime;

public class DateTimeHelpers
{
    public static int GetWeekNumber(System.DateTime time)
    {
        System.DateTime dt = time;

        //for now, take the the current executing thread's Culture
        var cultureInfo = Thread.CurrentThread.CurrentCulture;

        DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
        CalendarWeekRule weekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
        Calendar cal = cultureInfo.Calendar;

        return cal.GetWeekOfYear(dt, weekRule, firstDay);
    }

    public static int GetDayOfWeek(System.DateTime date)
    {
        return date.DayOfWeek switch
        {
            DayOfWeek.Sunday => 7,
            DayOfWeek.Monday => 1,
            DayOfWeek.Tuesday => 2,
            DayOfWeek.Wednesday => 3,
            DayOfWeek.Thursday => 4,
            DayOfWeek.Friday => 5,
            DayOfWeek.Saturday => 6,
            _ => 0,
        };
    }

    public static int DayToYearDay(string day, int week)
    {
        int dayNumber = day.ToLower() switch
        {
            "monday" => 1,
            "tuesday" => 2,
            "wednesday" => 3,
            "thursday" => 4,
            "friday" => 5,
            _ => 0,
        };

        return week * 7 + dayNumber;
    }
}
