﻿using System;
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
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using eaton.agir.webApi.util;

namespace eaton.agir.webApi {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<AgirContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("SmarterAspConnection")));
                
                 var signingConfigurations = new SigningConfigurations();
                services.AddSingleton(signingConfigurations);

                var tokenConfigurations = new TokenConfigurations();
                new ConfigureFromConfigurationOptions<TokenConfigurations>(
                    Configuration.GetSection("TokenConfigurations"))
                        .Configure(tokenConfigurations);
                services.AddSingleton(tokenConfigurations);


                services.AddAuthentication(authOptions =>
                {
                    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(bearerOptions =>
                {
                    var paramsValidation = bearerOptions.TokenValidationParameters;
                    paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                    paramsValidation.ValidAudience = tokenConfigurations.Audience;
                    paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                    // Valida a assinatura de um token recebido
                    paramsValidation.ValidateIssuerSigningKey = true;

                    // Verifica se um token recebido ainda é válido
                    paramsValidation.ValidateLifetime = true;

                    // Tempo de tolerância para a expiração de um token (utilizado
                    // caso haja problemas de sincronismo de horário entre diferentes
                    // computadores envolvidos no processo de comunicação)
                    paramsValidation.ClockSkew = TimeSpan.Zero;
                });

                // Ativa o uso do token como forma de autorizar o acesso
                // a recursos deste projeto
                services.AddAuthorization(auth =>
                {
                    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser().Build());
                });

            services.AddMvc ().AddJsonOptions (options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new Info {
                    Version = "V1",
                        Title = "Agir API",
                        Description = "Documentação de uso do projeto Agir API",
                        TermsOfService = "None",
                        Contact = new Contact { Name = "Lucas Lima", Email = "lucas-limagomes@hotmail.com", Url = "https://www.linkedin.com/in/lucas-lima-889237151/" }
                });

                c.DocInclusionPredicate ((docName, apiDesc) => {
                    if (apiDesc.HttpMethod == null) return false;
                    return true;
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = System.IO.Path.Combine (basePath, "AgirAPI.xml");

                c.IncludeXmlComments (xmlPath);
            });

            services.AddCors (o => o.AddPolicy ("MyPolicy", builder => {
                builder.AllowAnyOrigin ()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ();
            }));

            services.AddScoped (typeof (IBaseRepository<>), typeof (BaseRepository<>));
                        services.AddScoped (typeof (IUsuarioEventoRepository), typeof (UsuarioEventoRepository));

            services.AddScoped (typeof (IUsuarioRepository), typeof (UsuarioRepository));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseCors ("MyPolicy");
            app.UseMvc ();
            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "API V1");
            });

        }
    }
}