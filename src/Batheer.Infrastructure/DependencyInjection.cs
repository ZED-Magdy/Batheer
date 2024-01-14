//using Batheer.Application.Common.Interfaces;
//using Batheer.Infrastructure.Files;
//using Batheer.Infrastructure.Identity;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Models.Settings;
using Batheer.Infrastructure.Files;
using Batheer.Infrastructure.Identity;
using Batheer.Infrastructure.Persistence;
using Batheer.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
//using Batheer.Infrastructure.Services;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Batheer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("BatheerDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());


            services.AddSingleton<IQueryExecuter>(options => new QueryExecuter(configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IDomainEventService, DomainEventService>();

            //services
            //    .AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            services.AddTransient<IJwtToken, JwtToken>();

            //services.AddAuthentication()
            //    .AddIdentityServerJwt();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            //});


            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-GB");
            });

            services
              //.AddAuthentication()
              .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              //.AddAuthentication(auth =>
              //{
              //    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
              //    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              //})
              .AddJwtBearer(options =>
              {

                  options.RequireHttpsMetadata = false;
                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtToken:Secret"))),
                      ValidateIssuer = false,
                      //ValidIssuer = config.JwtToken.Issuer,
                      ValidateAudience = false,
                      //ValidAudience = config.JwtToken.Audience,
                  };
              })
              .AddCookie(coockieOptions =>
              {
                  coockieOptions.Cookie.HttpOnly = true;
                  coockieOptions.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                  coockieOptions.SlidingExpiration = true;

                  coockieOptions.LoginPath = "/account/login";
                  coockieOptions.LogoutPath = "/account/logout";
                  coockieOptions.Cookie.Name = "auth_coockie";
                  coockieOptions.AccessDeniedPath = "/account/AccessDenied";
              })
              ;


            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                   // CookieAuthenticationDefaults.AuthenticationScheme, 
                    JwtBearerDefaults.AuthenticationScheme
                   // , CookieAuthenticationDefaults.AuthenticationScheme
                    );
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });

            var emailConfig = configuration.GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();

            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }
    }
}