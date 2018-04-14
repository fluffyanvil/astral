using HhVacancyViewer.Core.ApiInterop;
using HhVacancyViewer.Core.Pg;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace HhVacancyViewer.WebApi
{
    public class Startup
    {
        private const string ApiTitle = "Vacancies API";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = ApiTitle, Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("HeadHunterDbContext");

            services.AddDbContext<HeadHunterDbContext>(builder => builder.UseNpgsql(connectionString));

            services.AddSingleton<IHeadHunterApi>(new HeadHunterApi());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ApiTitle} V1");
                c.RoutePrefix = "api-docs";
            });
        }
    }
}
