﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Cors.Infrastructure;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;



namespace dg
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


           

           

            // Add framework services.
            services.AddMvc();

            services.AddCors();
            services.Configure<CorsOptions>(options => options.AddPolicy("AllowAll",
                o => o.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll",
            //        o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});


            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseDefaultFiles();

            app.UseStaticFiles();


            //app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseMvc();

            app.UseCors("AllowAll");
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
