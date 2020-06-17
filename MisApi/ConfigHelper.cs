using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiRregConsulApi
{
    public class ConfigHelper
    {

        public static T Get<T>(string fileName)
        {
            //注意不是根目录的 config文件夹
            string basePath = Path.Combine(AppContext.BaseDirectory, "Configs");
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(fileName+".json",true,true);

            var configRoot =  builder.Build();
            if (configRoot == null)
            {
                return default;
            }

            return configRoot.Get<T>();
        }
    }
}
