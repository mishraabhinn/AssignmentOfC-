using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GetMachineNameAssestNameLastestAssest.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace GetMachineNameAssestNameLatestSeries
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            services.AddMvc(); 
            //.AddMvcOptions(o =>
            //{
            //    o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            //});
            //.AddJsonOptions(o =>
            //{
            //    if (o.SerializerSettings.ContractResolver != null)
            //    {
            //        var castedResolver = o.SerializerSettings.ContractResolver
            //                               as DefaultContractResolver;
            //        castedResolver.NamingStrategy = null;
            //    }
            //});

            services.AddTransient<CsvReader>();
            services.AddTransient<CuttingMachinesAccessories>();
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "LibraryOpenAPISpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "RestAPiGetMachineNameAssestNameLatestSeries",
                        Version = "1",
                        Description = "Through this API you can access machines and their accessories.",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "abhinn.mishra@klingelnberg.com",
                            Name = "Abhinn Mishra",
                            Url = new Uri("https://www.twitter.com/mishra_abhinn")
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }

                    });
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setupAction.IncludeXmlComments(xmlCommentsFullPath);

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
                app.UseExceptionHandler();

            }
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/LibraryOpenAPISpecification/swagger.json",
                    "RestAPiGetMachineNameAssestNameLatestSeries");
                setupAction.RoutePrefix = "";
            });
            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}
