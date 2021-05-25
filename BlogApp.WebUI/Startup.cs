using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI
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
            services.AddSingleton<IBlogRepository, BlogRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("BlogApp.WebUI")));
            services.AddMvc(options=>options.EnableEndpointRouting=false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions { 
                FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                RequestPath="/module"
            });

            app.UseMvc(route=>
            {
                route.MapRoute(
                    name:"default",
                    template:"{controller=Home}/{action=Index}/{id?}"
                    );
            });

            SeedData.Seed(app);
        }
    }
}
