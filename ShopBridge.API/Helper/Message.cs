using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Helper
{
    public static class Message
    {
        public static IConfiguration AppSetting { get; }
        static Message()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appMessage.json")
                    .Build();
        }
    }
}
