namespace Extensions;

public static class StringExtensions
{
    // Inspiration to different ways to check for null
    // https://www.thomasclaudiushuber.com/2020/03/12/c-different-ways-to-check-for-null/
    public static void CheckForNull(this string parameter)
    {
        _ = parameter ?? throw new ArgumentNullException(nameof(parameter));
    }

    /// <summary>
    /// Return true if parameter is null.
    /// </summary>
    public static bool IsNull(this string parameter)
    {
        return (parameter == null);
    }
}
