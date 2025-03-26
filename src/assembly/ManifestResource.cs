namespace Assembly;

public static class ManifestResource
{
    /// Get the full manifest resource name from the calling assembly and the resource file name.
    /// Remember that the manifest resource should be marked as "Embedded resource".
    /// If the resource is not found an FileNotFoundException is thrown.
    public static string GetManifestResourceName(string resourceFileName)
    {
        _ = resourceFileName ?? throw new ArgumentNullException(nameof(resourceFileName));

        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetCallingAssembly();

        return GetManifestResourceNameFromAssembly(assembly, resourceFileName);
    }

    public static string GetManifestResourceNameFromAssembly(System.Reflection.Assembly assembly, string resourceFileName)
    {
        _ = assembly ?? throw new ArgumentNullException(nameof(assembly));
        _ = resourceFileName ?? throw new ArgumentNullException(nameof(resourceFileName));

        string[] names = assembly.GetManifestResourceNames();
        var manifestFileName = names.SingleOrDefault(x => x.Contains(resourceFileName));

        return manifestFileName ?? throw new FileNotFoundException("Resource not found");
    }
}
