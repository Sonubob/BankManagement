using BankManagement.Middleware;
using BankManagement.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankManagement
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
            services.AddScoped<DbContext, BankDBContext>();
            services.AddScoped(typeof(IBankRepository<>), typeof(BankRepository<>));
            services.AddDbContext<BankDBContext>(options => options.UseSqlServer("get settings for DB COnnection"));
            services.AddControllers();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                foreach (var formatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(it => it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("applicaton/prd.mock-data"));
                }

                foreach (var formatter in options.InputFormatters.OfType<ODataOutputFormatter>().Where(it => it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("applicaton/prd.mock-data"));
                }
            }).ConfigureApplicationPartManager(m => m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
