using AutoMapper;
using CreditApproval.API.Models;
using CreditApproval.Domain.Dto;
using CreditApproval.Domain.Entities;
using CreditApproval.Domain.Interfaces;
using CreditApproval.Infra.Data;
using CreditApproval.Infra.Data.Repository;
using CreditApproval.Service.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CreditApproval.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Credit Approval API v1");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {         
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Credit Approval API", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IBaseRepository<Credit>, BaseRepository<Credit>>();
            services.AddScoped<IBaseService<Credit>, BaseService<Credit>>();
            services.AddScoped<IBaseService<Credit>, BaseService<Credit>>();
            services.AddScoped<IProcessamentoCreditoService, ProcessamentoCreditoService>();


            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateCreditModel, Credit>();
                config.CreateMap<UpdateCreditModel, Credit>();
                config.CreateMap<Credit, CreditModel>();
            }).CreateMapper());
        }
    }
}
