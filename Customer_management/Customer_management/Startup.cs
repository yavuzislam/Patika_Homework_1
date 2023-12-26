using System.Reflection;
using Customer_management.DbOperation;
using Customer_management.Middlewares;
using Customer_management.Services;
using Microsoft.EntityFrameworkCore;

namespace Customer_management;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<CustomerManagementDbContext>(options =>
            options.UseInMemoryDatabase("CustomerManagementDB"));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSingleton<ILoggerService, ConsoleLogger>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseCustomExceptionMiddleware();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}