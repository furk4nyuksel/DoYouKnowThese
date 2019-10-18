using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using DoYouNowThese.API.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
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

 

            services.AddMvc(config =>
            {
                config.Filters.Add<MyExceptionFilter>();
                config.Filters.Add<MyActionFilter>();

            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //doğrulama şemalarımı ekliyorum.
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
                )
                //options parametresinin özelliklerini belirliyorum.
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidAudience = "194.169.120.27",
                        ValidateIssuer = true,
                        ValidIssuer = "194.169.120.27",
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes("bu_benim_muhtesem_uzunluktaki_muhtesem_saklanmis_guvelik_keyim"))
                    };



                    // token doğrulandığında ve çalışır olma süresi dolduğunda devreye giren iki eventim.
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = ctx =>
                        {
                            ctx.Success();
                            //Gerekirse burada da gelen token içerisindeki çeşitli bilgilere göre doğrulama yapabilmemiz mümkün.
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = ctx =>
                        {
                            Console.WriteLine("Exception:{0}", ctx.Exception.Message);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "You api title", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
        { "Bearer", Enumerable.Empty<string>() },
    });

            });

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Swager", "");
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
            app.UseMvc();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "swagger Test .NetCore");
            });
 
            app.UseMvc();

            app.UseAuthentication();

        }


    }
}
