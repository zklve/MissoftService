using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.Cache;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
using Ocelot.Values;

namespace OcelotDemoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //鉴权中心
            string authKey = "UserGatewayKey";
            services.AddAuthentication("Bearer")
               .AddIdentityServerAuthentication(authKey, option =>
               {
                    //鉴权中心
                   option.Authority = "http://localhost:7200";
                   option.ApiName = "UserApi";
                   option.RequireHttpsMetadata = false;
                   option.SupportedTokens = SupportedTokens.Both;
               });

            //services.AddControllers();
            services.AddOcelot()
                //服务注册与发现
                .AddConsul()
                //.AddCacheManager(configBuilder => { configBuilder.WithDictionaryHandle(); })
                //限流
                .AddPolly()
                ;
            //自定义缓存
            //services.AddSingleton<IOcelotCache<>>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOcelot();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
