using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using PsefApi.Model;

namespace PsefApi
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
            services.AddControllers();
            services
                .AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration.GetSection("Bearer").GetValue<string>("Authority");
                    options.Audience = Configuration.GetSection("Bearer").GetValue<string>("Audience");
                });

            string[] knownProxies = Configuration.GetSection("KnownProxies").Get<string[]>();

            services
                .AddMemoryCache()
                .AddDbContextPool<Model.PsefContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("Application"),
                        sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(
                                10,
                                TimeSpan.FromSeconds(30),
                                null);
                        }), 16)
                .Configure<ForwardedHeadersOptions>(options =>
                {
                    options.ForwardLimit = 2;

                    foreach (string proxy in knownProxies)
                    {
                        if (String.IsNullOrEmpty(proxy))
                        {
                            continue;
                        }

                        options.KnownProxies.Add(IPAddress.Parse(proxy));
                    }
                });

            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpsRedirection()
                .UsePathBase(new PathString(Configuration.GetValue<string>("BasePath")))
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
                    endpoints.MapODataRoute("odata", "odata", GetEdmModel());
                });
        }

        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Apotek>(nameof(Apotek));
            odataBuilder.EntitySet<DesaKelurahan>(nameof(DesaKelurahan));
            odataBuilder.EntitySet<KabKota>(nameof(KabKota));
            odataBuilder.EntitySet<Provinsi>(nameof(Provinsi));
            odataBuilder.EntitySet<Pemohon>(nameof(Pemohon));

            return odataBuilder.GetEdmModel();
        }
    }
}
