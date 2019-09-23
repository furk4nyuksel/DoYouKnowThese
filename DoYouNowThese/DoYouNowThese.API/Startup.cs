using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace DoYouNowThese.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new Info
                {
                    Title = "Swagger For Test",
                    Version = "1.0.0",
                    Description = "Try Swagger on (ASP.NET Core 2.1)",
                    Contact = new Contact()
                    {
                        Name = "Swagger Implementation Furkan Yüksel",
                        Url = "http://teknohisar.ocm",
                        Email = "info@teknohisar.com"
                    },
                    TermsOfService = "http://swagger.io/terms/"
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc()
         .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "www.test.com",
            ValidAudience = "www.test.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))
        };
    });
            services.AddMvc();


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
            app.UseMvc();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseAuthentication();
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "swagger Test .NetCore");
            });

        }


    }
}
