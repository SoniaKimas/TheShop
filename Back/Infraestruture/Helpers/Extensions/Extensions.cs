namespace Infraestruture.Helpers.Extensions;
public static class DateTimeExtensions
{

    /// <summary>
    /// gets the start of the current week, if today is monday, it will return today
    /// </summary>
    public static DateTime StartOfCurrentWeek(this DateTime _)
    {
        DateTime today = DateTime.Today;
        int deltaToStartOfWeek = DayOfWeek.Monday - today.DayOfWeek;
        // start of the week is monday
        if (today.DayOfWeek == DayOfWeek.Sunday)
        {
            deltaToStartOfWeek = -6;
        }
        return today.AddDays(deltaToStartOfWeek);
    }


    /// <summary>
    /// gets the end of the current week, if today is sunday, it will return today
    /// </summary>
    public static DateTime EndOfCurrentWeek(this DateTime _)
    {
        DateTime today = DateTime.Today;
        // start of the week is monday
        int deltaToEndOfWeek = DayOfWeek.Sunday - today.DayOfWeek;
        return today.AddDays(deltaToEndOfWeek);
    }
}