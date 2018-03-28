using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TinyUrl.Data;
using TinyUrl.Data.Repositories;
using TinyUrl.Services;
using TinyUrl.Web.Services;

namespace TinyUrl.Web
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
            services.AddDbContextPool<TinyUrlContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("database"));
            });
            services.AddMvc();

            services.AddScoped<ITinyUrlRepository, TinyUrlsRepository>();
            services.AddScoped<IUrlShorteningService, DefaultUrlShorteningService>();
            //services.AddTransient<IShortURLBuilder, DefaultShortURLBuilder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
