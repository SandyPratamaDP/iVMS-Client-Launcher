using System.Diagnostics;
using System.Security;

class Program
{
    static void Main(string[] args)
    {
        // Path to the executable file
        string exePath = "C:\\Program Files (x86)\\iVMS-4200 Site\\iVMS-4200 Client\\Client\\iVMS-4200.Framework.C.exe";

        // Username and password for admin account
        string username = "username";
        string password = "password";

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = exePath,
            UseShellExecute = false,
            Domain = "domain",
            UserName = username
        };

        // Create a SecureString object for the password
        SecureString securePassword = new SecureString();
        foreach (char c in password)
        {
            securePassword.AppendChar(c);
        }
        startInfo.Password = securePassword;

        // Set the Verb property to run the process as administrator
        startInfo.Verb = "runas";

        try
        {
            Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
