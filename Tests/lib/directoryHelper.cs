using System;

namespace Tests.lib;

public static class directoryHelper
{
    public static string RelativeToHome(string pathRelativeToHome)
    {
        return System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            pathRelativeToHome
        );
    }
}