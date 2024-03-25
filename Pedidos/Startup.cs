using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pedidos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Pedidos.IoC;
using Pedidos.Application.AutoMapper;
using AutoMapper;
using Pedidos.Swagger;
using System.Text;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Newtonsoft.Json;

namespace Template
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(
                x => x.UseSqlite(Configuration.GetConnectionString("Connection"))
            );

            services.AddControllers().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => { opts.ResourcesPath = "Resources"; })
                    .AddDataAnnotationsLocalization()
                    .AddNewtonsoftJson(options =>
                    {
                        var dateConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter
                        {
                            DateTimeFormat = "yyyy'-'MM'-'dd"
                        };

                        options.SerializerSettings.Converters.Add(dateConverter);
                        options.SerializerSettings.Culture = new CultureInfo("en-IE");
                        options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    });

            NativeInjector.RegisterServices(services);

            services.AddAutoMapper(typeof(AutoMapperSetup));
            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfiguration();
            }

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
