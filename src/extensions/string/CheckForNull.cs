namespace Csharp.Extensions;

public static partial class String
{
    /// <summary>
    /// Check for null using the null-coalescing operator.
    /// </summary>
    public static void CheckForNull(this string parameter)
    {
        _ = parameter ?? throw new ArgumentNullException(nameof(parameter));
    }
}
