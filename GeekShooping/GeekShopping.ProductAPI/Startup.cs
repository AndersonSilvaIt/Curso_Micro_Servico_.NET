using Microsoft.EntityFrameworkCore;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace GeekShopping.ProductAPI
{
    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }

    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }
        public IHostEnvironment _hostEnvironment { get; }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(hostEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            _hostEnvironment = hostEnvironment;

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.ProductAPI", Version =  "v1"});
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MySQLContext>(options =>
            {
                options.UseNpgsql(connection, builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                .CommandTimeout(10));
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();
        }
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Environment) as IStartup;

            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            startup.ConfigureServices(webAppBuilder.Services);

            var app = webAppBuilder.Build();

            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            try
            {
                using (var builders = webAppBuilder.Services.BuildServiceProvider())
                {
                    startup.Configure(app, app.Environment);

                    //var contextIdentity = builders.GetService<PGContext>();
                    //contextIdentity?.Database.Migrate();
                }

            }
            catch (Exception ex)
            {
            }

            app.Run();

            return webAppBuilder;
        }
    }
}
