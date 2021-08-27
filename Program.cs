using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EzRemoteExecutor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@$"
 _____   ______                     _       _____                    _             
|  ___|  | ___ \                   | |     |  ___|                  | |            
| |__ ___| |_/ /___ _ __ ___   ___ | |_ ___| |____  _____  ___ _   _| |_ ___  _ __ 
|  __|_  |    // _ | '_ ` _ \ / _ \| __/ _ |  __\ \/ / _ \/ __| | | | __/ _ \| '__|
| |___/ /| |\ |  __| | | | | | (_) | ||  __| |___>  |  __| (__| |_| | || (_) | |   
\____/___\_| \_\___|_| |_| |_|\___/ \__\___\____/_/\_\___|\___|\__,_|\__\___/|_|   

- A remote executor thats actually fucking simple...
");
            Console.ResetColor();
            CreateHostBuilder(args).Build().Run();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    IPAddress localIpAddress = IPAddress.Parse(GetLocalIPAddress());

                    if (Debugger.IsAttached)
                    {
                        options.ListenLocalhost(6165);
                    }
                    else
                    {
                        // 80
                        options.Listen(localIpAddress, 6165);

                        // 443
                        options.Listen(localIpAddress, 6166);
                    }
                })
               .UseStartup<Startup>();
    }
}
