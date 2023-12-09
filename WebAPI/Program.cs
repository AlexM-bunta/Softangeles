using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebAPI.EntityFramework.Context;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration.GetConnectionString("BankingDatabase") ?? string.Empty;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers();
services.AddCors();

services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
        options.EnableDetailedErrors();
    }
    , ServiceLifetime.Singleton);

foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    foreach (Type interfaceType in assembly.GetTypes().Where(t => t.IsInterface))
    {
        if (interfaceType.Namespace != null && (interfaceType.Namespace.Equals("WebAPI.Interfaces")))
        {
            Type? serviceImplementation = assembly.GetTypes().FirstOrDefault(p => p.IsClass && p.GetInterfaces().Contains(interfaceType));

            if (serviceImplementation != null)
            {
                services.AddSingleton(interfaceType, serviceImplementation);
            }
        }
    }
}

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsBuilder => corsBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMvc();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();

app.Run();
