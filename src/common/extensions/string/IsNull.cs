namespace Csharp.Common;

public static partial class String
{
    /// <summary>
    /// Return true if parameter is null.
    /// </summary>
    public static bool IsNull(this string parameter)
    {
        return (parameter == null);
    }
}
