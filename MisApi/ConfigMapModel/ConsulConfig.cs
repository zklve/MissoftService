using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisApi.ConfigMapModel
{
    public class ConsulConfig
    {
        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public int Weight { get; set; }
    }
}
