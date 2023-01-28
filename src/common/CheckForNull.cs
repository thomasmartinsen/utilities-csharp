/// Different ways to check for null
/// Source:
/// https://www.thomasclaudiushuber.com/2020/03/12/c-different-ways-to-check-for-null/

public class CheckForNull
{
    public void __(string parameter)
    {
        _ = parameter ?? throw new ArgumentNullException(nameof(parameter));

        if (parameter is null) { }

        if (parameter is not null) { }
    }
}
