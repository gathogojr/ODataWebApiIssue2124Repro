using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NS.Data;
using System.Linq;

namespace NS
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
            services.AddSingleton(this.Configuration);
            services.AddDbContext<ReproDbContext>(options => options.UseMySql(@"Server=localhost;Port=3306;Database=Repro2124Db;User=root;Password=r0Cks0l1d;Charset=utf8;"));
            services.AddMvc(options => { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc(routeBuilder => {
                routeBuilder.Filter().Expand().Select().OrderBy().MaxTop(null).SkipToken();
                routeBuilder.MapODataServiceRoute("odata", "odata", ConfigurationHelper.GetEdmModel());
            });
        }
    }
}
