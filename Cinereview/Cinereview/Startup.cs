using Cinereview.Configuration;
using Cinereview.Repositories;
using Cinereview.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview
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
            //Atribui valor à classe Settings, para ser usada a ConnectionString do banco de dados
            services.Configure<Settings>(options => Configuration.GetSection("Settings").Bind(options));

            //Registrar Classe do MongoDB
            services.AddScoped<MongoDBContext>();

            //Registro - Services
            services.AddScoped<UserService>();

            //Registro - Repositories
            services.AddScoped<UserRepository>();

            //Registra as controllers que implementam a "ControllerBase" e usam o decorator "[ApiController]"
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Verifica ambiente
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Registra Endpoints - Inicio
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Fim
        }
    }
}
