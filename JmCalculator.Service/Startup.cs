using JmCalculator.Service.Config;
using JmCalculator.Service.Data;
using JmCalculator.Service.Processors;
using JmCalculator.Service.Repositories;
using JmCalculator.Shared.Contracts;
using JmCalculator.Shared.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace JmCalculator.Service
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

            services.Configure<JmCalculatorConfig>(
              Configuration.GetSection(nameof(JmCalculatorConfig)));

            services.AddSingleton<IJmCalculatorConfig>(sp => sp.GetRequiredService<IOptions<JmCalculatorConfig>>().Value);
            services.AddFactoryMethod<IJmPriceDataStorage, MongoDbPriceDataStorage>();
            services.AddFactoryMethod<IJmOptionDataStorage, MongoDbOptionDataStorage>();
            services.AddTransient<IJmPriceRepository, JmPriceRepository>();
            services.AddTransient<IJmOptionsRepository, JmOptionsRepository>();
            services.AddTransient<IJmPriceProcessor, JmPriceProcessor>();
            services.AddTransient<IJmPriceValidator, JmPriceValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    static class ServiceCollectionExtentions
    {
        public static void AddFactoryMethod<TInterface, TImplementation>(this IServiceCollection services)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            services.AddTransient<TInterface, TImplementation>();
            services.AddSingleton<Func<TInterface>>(s => () => s.GetService<TInterface>());
        }
    }
}
