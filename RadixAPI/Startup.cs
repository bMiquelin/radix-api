using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RadixAPI.Data;
using Microsoft.EntityFrameworkCore;
using RadixAPI.Authorization;
using RadixAPI.Managers;
using RadixAPI.Providers;
using RadixAPI.AntiFraud;
using RadixAPI.AntiFraud.ClearSale;

namespace RadixAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RadixAPIContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Azure")));
            services.AddScoped<StoreAuthorization>();
            services.AddTransient<TransactionManager>();
            services.AddTransient<ProviderIterator>();
            services.AddTransient<IAntiFraudProvider, ClearSale>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
        }
    }
}
