using AutoMapper;
using BlogEngine.Data;
using BlogEngine.Data.Abstract;
using BlogEngine.Data.Repositories;
using BlogEngine.Web.Infrastructure;
using BlogEngine.Web.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogEngine.Web
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
            services.AddRazorPages(opt => 
            {
                opt.Conventions.ConfigureFilter(new ValidatorPageFilter());
            });
            services.AddDbContext<BlogEngineContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BlogEngineContext"),
                    b => b.MigrationsAssembly("BlogEngine.Data")));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPostTagRepository, PostTagRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddAutoMapper(typeof(MappingProfile));
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
