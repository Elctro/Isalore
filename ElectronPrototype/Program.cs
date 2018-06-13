using System.Runtime.InteropServices;
using ElectronNET.API;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ElectronPrototype
{
    public class Program
    {
        public static OperatingSystem OperatingSystem;

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                OperatingSystem = OperatingSystem.Windows;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                OperatingSystem = OperatingSystem.Osx;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                OperatingSystem = OperatingSystem.Linux;
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseElectron(args)
                .Build();
        }
    }
}