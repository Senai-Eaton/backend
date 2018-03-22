using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eaton.agir.domain.Contracts;
using eaton.agir.repository.Context;
using eaton.agir.repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace eaton.agir.webApi
{
    public class Startup
    {
         public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
                        services.AddDbContext<AgirContext>(options => 
                                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            
            
            
              services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
               services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info {
                    Version = "V1",
                    Title = "Agir API",
                    Description = "Documentação de uso do projeto Agir API",
                    TermsOfService = "None",
                    Contact = new Contact{Name = "Lucas Lima", Email = "lucas-limagomes@hotmail.com", Url = "https://www.linkedin.com/in/lucas-lima-889237151/"}
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = System.IO.Path.Combine(basePath, "AlimenteSeBemAPI.xml");

                c.IncludeXmlComments(xmlPath);
            });
             services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                {
                   builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
               }));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                });     

            
        }
    }
}
