using Consul;
using Microsoft.Extensions.Configuration;
using MisApi.ConfigMapModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisApi
{
    public static class ConsulHelper
    {
        public static void ConsulRegist(this IConfiguration configuration)
        {
            var consulConfig = ConfigHelper.Get<ConsulConfig>("consul");
            ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500");
                c.Datacenter = "dc1";
            });

            string ip = consulConfig.IP;
            int port = consulConfig.Port;
            int weight = consulConfig.Weight;

            client.Agent.ServiceRegister(new AgentServiceRegistration
            {
                ID = "service" + Guid.NewGuid(),
                Name= "zklService",
                Address=ip,
                Port = port,
                Tags =new string[] { weight.ToString() },
                Check = new AgentServiceCheck
                {
                    Interval = TimeSpan.FromSeconds(12),
                    HTTP = $"http://{ip}:{port}/api/user/HealthCheck",
                    Timeout = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10)
                }
            }) ;
        }

    }

}
