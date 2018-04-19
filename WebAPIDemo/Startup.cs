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
using SwashBuckle.AspNetCore;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;

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

            services.AddTransient<ITestTableRepository, TestTableRepository>();
            
            services.AddTransient<IEFUnitOfWork, EFUnitOfWork>();

            //获取主项目的版本号，在属性当中设置
            string strVersion = "V" + Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationVersion;
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc(strVersion, new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "WebAPIDemo",
                    Version = strVersion,
                    Description = "Test API demo",
                    TermsOfService = "Terms of Service"
                });
                options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "WebAPIDemo.xml")); // 注意：此处替换成所生成的XML documentation的文件名。
                options.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            string strVersion = "V" + Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationVersion;
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/" + strVersion + "/swagger.json", "Contacts API V1");
            });
        }
    }
}
