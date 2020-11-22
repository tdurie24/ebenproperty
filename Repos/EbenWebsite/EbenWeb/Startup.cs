using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Eben.Business.Contracts;
using Eben.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

namespace EbenWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //var logLevel = configuration.GetSection("Logging").GetSection("LogLevel").GetValue<string>("Default");

            //var levelSwitch = new LoggingLevelSwitch
            //{
            //    MinimumLevel = (Serilog.Events.LogEventLevel)Enum.Parse(typeof(Serilog.Events.LogEventLevel), logLevel, true)
            //};
           //var loc = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
           // var logpath = System.IO.Path.GetDirectoryName(loc);
           // Log.Logger = new LoggerConfiguration()
           //     .MinimumLevel.ControlledBy(levelSwitch)
           //     .Enrich.WithThreadId()
           //     .WriteTo.File(
           //         path: logpath + "\\wwwroot\\Logs",
           //         rollingInterval: RollingInterval.Day,
           //         rollOnFileSizeLimit: true,
           //         fileSizeLimitBytes: 52428800,
           //         outputTemplate: "{Timestamp: yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]<{ThreadId}> {Message:lj} {NewLine}{Exception}")
           //     .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

          //  services.AddTransient<IEmailService, EmailService>();
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
