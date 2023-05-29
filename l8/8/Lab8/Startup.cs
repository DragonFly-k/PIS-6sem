using Lab8.Context;
using Lab8.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Lab8
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //используется для конфигурации служб, которые будут доступны для внедрения зависимостей.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();//добавляет службы MVC
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(@"C:\Users\User\Desktop\Новая папка\asp\8\Lab8.xml");
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lab8", Version = "v1" });
            });

            services.AddDbContext<UserContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("UserDatabase")));
            services.AddTransient(typeof(UserRepository));
        }

        //настройки конвейера обработки HTTP-запросов. 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab8 v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}