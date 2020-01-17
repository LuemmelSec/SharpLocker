using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // To retrieve background image from powershell
            /*
             * 
            
            # load UWP namespace Windows.System.UserProfile
            [Windows.System.UserProfile.LockScreen,Windows.System.UserProfile,ContentType=WindowsRuntime] | Out-Null
            # load SharpLocker NET assembly
            Add-Type -Path .\SharpLockerLib.dll
            # Invoke SharpLocker (parameter is an optional string pointing to the file with the current user's LockScreen Background)
            [SharpLockerLib.Runner]::Run([Windows.System.UserProfile.LockScreen]::OriginalImageFile.AbsolutePath)
             * 
             */


            // Version with custom background

            // String input = SharpLockerLib.Runner.Run(@"C:/Users/XMG-U705/Pictures/XMG_Wallpaper_Planet_2015_N_01_2560_1440.jpg");

            // Version with default background
            String input = SharpLockerLib.Runner.Run();
            Console.WriteLine(input);
            Console.WriteLine("press key to exit");
            Console.ReadKey(); // keep console Window open
        }
    }
}
