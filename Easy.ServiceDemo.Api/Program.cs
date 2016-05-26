using Easy.Public;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Easy.Rpc.directory;
using Easy.Rpc.Monitor;

namespace Easy.ServiceDemo.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = IpHelper.InternetIp4();
            int port = GetPort(ip);

            var isRegsiterToRegiserCenter = StringHelper.ToInt32(ConfigurationManager.AppSettings["isRegsiterToRegiserCenter"], 1);
            if (isRegsiterToRegiserCenter == 1)
            {
                string registerUrl = ConfigurationManager.AppSettings["registerUrl"];
                string redisUrl = ConfigurationManager.AppSettings["redisUrl"];
                int databaseIndex = int.Parse(ConfigurationManager.AppSettings["databaseIndex"]);
                var builder = new RedisDirectoryBuilder(registerUrl, redisUrl);
                builder.Build(new MySelfInfo()
                {
                    Description = "Demo子服务",
                    Directory = "ServiceDemo",
                    Status = 1,
                    Weight = 10,
                    Url = string.Format("http://{0}:{1}/api/", ip, port),
                    Ip = ip + ":" + port
                }, new string[] { }, new string[]
                {
                    "Demo/SayHello",
                    "Demo/GetStudentInfo",
                    "Home/Index"
                });

                string monitorUrl = ConfigurationManager.AppSettings["monitorUrl"];
                MonitorManager.RegisterSend(new HttpSendCollectorData(monitorUrl));
            }



            string baseUrl = string.Format("http://{0}:{1}/", ip, port);
            using (WebApp.Start<Startup>(new StartOptions(baseUrl)))
            {
                System.Console.WriteLine("服务启动中...");
                while (true)
                {
                    Thread.Sleep(80000012);
                }
            }

            
        }

        private static int GetPort(string ip)
        {
            string portfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "port.txt");

            if (File.Exists(portfile))
            {
                return int.Parse(File.ReadAllText(portfile));
            }

            int port = Easy.Public.IpHelper.GetAvailablePort(ip, 8000, 9999);

            File.WriteAllText(portfile, port.ToString());
            return port;
        }
    }
}
