using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Domains.IRespositories;
using Repository.Repositories;
using Repository.UnitOfWork;

namespace WebAPIDemo
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
            services.AddDbContext<Domains.Model.liweitestContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc();

            services.AddTransient<Services.IServices.ITestTableService, Services.Services.TestTableService>();
            
            services.AddTransient<ITestTableRepository, TestTableRepository>();
            
            services.AddTransient<IEFUnitOfWork, EFUnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
