using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UI.WebApi.Data.Repositorios;
using UI.WebApi.Interfaces;
using UI.WebApi.Servico;
using Swashbuckle.AspNetCore.Swagger;
using static UI.WebApi.Data.Context.ReservaCarroContexto;
using Steeltoe.Discovery.Client;

namespace UI.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<IReservaCarroRepositorio, ReservaCarroRepositorio>();
            services.AddTransient<IReservaCarroServico, ReservaCarroServico>();

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Reserva de carro",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core 2.2 para reserva de carro"
                    });
            });
            services.AddDiscoveryClient(Configuration);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reserva de carro V1");
            });


            //app.UseHttpsRedirection();
            app.UseDiscoveryClient();
            app.UseMvc();
        }
    }
}
