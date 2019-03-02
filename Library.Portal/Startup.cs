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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Portal
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<LibraryDbContext>(
                cfg =>
                {
                    cfg.UseSqlServer(_configuration.GetConnectionString("LibraryConnection"));
                });

            services.AddScoped<DbContext, LibraryDbContext>();

            services.AddTransient<ILanguageBusiness, LanguageBusiness>();
            services.AddTransient<IUnitOfWork<Language>, UnitOfWork<Language>>();
            services.AddTransient<IRepository<Language>, Repository<Language>>();

            services.AddTransient<IGenderBusiness, GenderBusiness>();
            services.AddTransient<IUnitOfWork<Gender>, UnitOfWork<Gender>>();
            services.AddTransient<IRepository<Gender>, Repository<Gender>>();

            services.AddTransient<IAuthorBusiness, AuthorBusiness>();
            services.AddTransient<IUnitOfWork<Author>, UnitOfWork<Author>>();
            services.AddTransient<IRepository<Author>, Repository<Author>>();

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
