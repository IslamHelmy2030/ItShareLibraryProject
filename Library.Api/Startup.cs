using AutoMapper;
using Library.Data.Context;
using Library.Data.Entities;
using Library.Domain.Business;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto;
using Library.Domain.Dto.Interfaces;
using Library.Repositories.Repository;
using Library.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;


namespace Library.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(
                cfg =>
                {
                    cfg.UseSqlServer(_configuration.GetConnectionString("LibraryConnection"));
                });

            services.AddScoped<DbContext, LibraryDbContext>();

            services.AddTransient<IGenderBusiness, GenderBusiness>();
            services.AddTransient<ILanguageBusiness, LanguageBusiness>();

            services.AddTransient<IGenderDto, GenderDto>();
            services.AddTransient<ILanguageDto, LanguageDto>();

            services.AddTransient<IUnitOfWork<Gender>, UnitOfWork<Gender>>();
            services.AddTransient<IRepository<Gender>, Repository<Gender>>();

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

           services.AddSwaggerGen(cfg =>cfg.SwaggerDoc("v1", new Info { Title = "Library API V1", Version = "v1" }));



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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
