using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RrepTest.Filters;
using RrepTest.Interfaces.IRepository;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;
using RrepTest.MyExceptions;
using RrepTest.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace RrepTest
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

            services.AddAutoMapper();
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration["ConnString:RepoKanc"]));
            services.AddMvc(option =>
            {
                option.Filters.Add(typeof(UnitFilter));
                option.Filters.Add(typeof(MyExceptionFilter));
                option.Filters.Add(typeof(RresultFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IOsobaRepository, OsobaRepository>();
            services.AddScoped<IUredjajRepository, UredjajRepository>();
            services.AddScoped<IKancelarijaRepository, KancelarijaRepository>();
            services.AddScoped<IKoriscenjeUredjajaRepository, KoriscenjeUredjajaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

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
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
