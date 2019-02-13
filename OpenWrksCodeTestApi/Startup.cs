using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenWrksCodeTestApi.Business;
using OpenWrksCodeTestApi.Core.Contracts;
using OpenWrksCodeTestApi.Data;
using OpenWrksCodeTestApi.Data.DbContexts;
using System;
using System.Text;

namespace OpenWrksCodeTestApi
{
    public class Startup
    {
        private const string JwtBearer = "JwtBearer";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Use an in memory DB for this example application
            services.AddDbContext<ClientContext>(opt => opt.UseInMemoryDatabase("ApiClients"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearer;
                opts.DefaultChallengeScheme = JwtBearer;
            })
            .AddJwtBearer(JwtBearer, jwtOpts =>
            {
                jwtOpts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OpenWrksOpenWrksOpenWrks")),
                    ValidateIssuer = true,
                    ValidIssuer = "OpenWrksCodeTestApi",
                    ValidateLifetime = true,
                    ValidateAudience = false //Ignore the audiance - don't care for this example
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
