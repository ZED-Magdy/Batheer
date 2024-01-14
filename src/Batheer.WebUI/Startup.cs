using Batheer.Application;
using Batheer.Application.Common.Interfaces;
//using Batheer.WebUI.Data;
using Batheer.Infrastructure;
using Batheer.Infrastructure.Persistence;
using Batheer.WebUI.Filters;
using Batheer.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using NSwag;
//using NSwag.Generation.Processors.Security;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Batheer.WebUI.Common.ModelBinders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.DataProtection;
using Batheer.Application.Common.Models.Settings;
using Serilog;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Coravel;
using Batheer.WebUI.TaskSchedulings;
using Batheer.WebUI.Middlewares;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Razor;
using Batheer.WebUI.Common.RazorViewEngines;

namespace Batheer.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddMetrics();

            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped<IHttpContextService, HttpContextService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<Infrastructure.Persistence.ApplicationDbContext>();

            //services.AddControllersWithViews(options =>
            //  options.Filters.Add<ApiExceptionFilterAttribute>())
            //      .AddFluentValidation();


            services.AddControllersWithViews(options =>
            {
                //options.Filters.Add<ApiExceptionFilterAttribute>();

                // add the custom binder at the top of the collection
                options.ModelBinderProviders.Insert(0, new FormFileModelBinderProvider());
                options.ModelBinderProviders.Insert(0, new GoogleMapValuesDtoModelBinderProvider());
            })
                .AddFluentValidation();

            services.Configure<RazorViewEngineOptions>(o =>
            {
                o.ViewLocationExpanders.Add(new CustomViewLocationExpander());
            });


            services.AddRazorPages();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Batheer API", Version = "v1" });


                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {securityScheme, new string[] { }}
                    });

            });

            /*
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Batheer API";
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            */

            services.Configure<RequestLocalizationOptions>(options =>
            {
                //https://dotnetcoretutorials.com/2017/06/22/request-culture-asp-net-core/
                //https://www.dotnetcurry.com/aspnet/1314/aspnet-core-globalization-localization
                options.DefaultRequestCulture = new RequestCulture("en-GB");
            });

            #region AddDataProtection
            var dataProtectionConfig = Configuration.GetSection("DataProtectionConfiguration")
                .Get<DataProtectionConfiguration>();
            var keysFolder = Path.Combine(Environment.ContentRootPath, dataProtectionConfig.keysFolderName);

            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(keysFolder))
                .SetApplicationName(dataProtectionConfig.ApplicationName)
                .SetDefaultKeyLifetime(TimeSpan.FromDays(dataProtectionConfig.KeyLifetime_FromDays));

            #endregion


            services.AddScheduler();
            services.AddTransient<SendSMSToTheIntendedBeneficiariesSchedule>();
            services.AddTransient<SMSService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHealthChecks("/health");

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Batheer API v1"));


            /*
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });
            */
            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            //app.UseMiddleware<JwtMiddleware>();


            if (env.IsProduction())
            {
                app.ApplicationServices
                .UseScheduler(scheduler =>
                {
                    scheduler.Schedule<SendSMSToTheIntendedBeneficiariesSchedule>()
                    .EveryFiveMinutes()
                    .PreventOverlapping(nameof(SendSMSToTheIntendedBeneficiariesSchedule));

                    //scheduler.Schedule(
                    //    () => Console.WriteLine($"Every minute during the week.{DateTime.Now}")
                    //)
                    //.EveryMinute();
                })
                .OnError((exception) =>
                    Console.WriteLine($"Exception :: {exception.Message}")
                );
            }


            //app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
