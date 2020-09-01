using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NS.Data;
using NS.Models;
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
            services.AddDbContext<ReproDbContext>(options => options.UseSqlServer(
                connectionString: @"Data Source=(LocalDb)\MSSQLLocalDB; Integrated Security=True; Persist Security Info=True; MultipleActiveResultSets=True; Database=Repro2124Db")
            );
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

            AddSeedData(app);
        }

        private static void AddSeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ReproDbContext>();

                if (!db.Projects.Any())
                {
                    db.Employees.Add(new Employee { Name = "Nancy Davolio" });
                    db.Employees.Add(new Employee { Name = "Andrew Fuller" });

                    db.Projects.AddRange(
                        new[]
                        {
                        new Project { Name = "Pipeline Installation" }
                        });

                    db.Tasks.AddRange(
                        new[]
                        {
                        new Task { Description = "Install Piping", ProjectId = 1, SupervisorId = 1 },
                        new Task { Description = "Install Couplings", ProjectId = 1, SupervisorId = 1 },
                        new Task { Description = "QA Inspection", ProjectId = 1, SupervisorId = 2 }
                        });

                    db.SaveChanges();

                }
            }

        }
    }
}
