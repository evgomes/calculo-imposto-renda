using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using IncomeTax.API.Domain.Repositories;
using IncomeTax.API.Domain.Services;
using IncomeTax.API.Domain.Services.Calculations;
using IncomeTax.API.Persistence.EF.Contexts;
using IncomeTax.API.Persistence.EF.Repositories;
using IncomeTax.API.Services;
using IncomeTax.API.Services.Calculations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace IncomeTax.API.Client
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("incometax"));

            services.AddScoped<IBasicWageRepository, BasicWageRepository>();
            services.AddScoped<ITaxpayerRepository, TaxpayerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBasicWageService, BasicWageService>();
            services.AddScoped<ITaxpayerService, TaxpayerService>();
            services.AddScoped<IIncomeTaxCalculatorService, IncomeTaxCalculatorService>();

            services.AddAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "API de Cálculo de Imposto de Renda",
                            Version = "v1",
                            Description = "API para cadastro de contribuintes do imposto de renda. Baseado nos dados de renda bruta mensal e dependentes, a alíquota do imposto e valor a ser pago de cada contribuinte são calculadas.",
                            Contact = new Contact
                            {
                                Email = "evandro.ggomes@outlook.com",
                                    Name = "Evandro Gayer Gomes",
                            },
                            License = new License
                            {
                                Name = "MIT"
                            }
                    });

                // Adiciona comentários XML a documentaçao do Swagger.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Cálculo de Imposto de Renda V1");
            });

            app.UseMvc();
        }
    }
}