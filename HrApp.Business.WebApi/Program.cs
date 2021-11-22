using HrApp.Business.WebApi.Helpers;
using HrApp.BusinessRules;
using HrApp.Interfaces.BusinessRules;
using HrApp.Interfaces.Persistence;
using HrApp.Persistence.EfCore;
using HrApp.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()))
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<HrAppContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:HrAppConnection")
#if DEBUG
                .LogTo(Log.Logger.Debug, LogLevel.Debug)
#endif
                ;
}, ServiceLifetime.Scoped);

builder.Services.AddSingleton<IObjectModelValidator, NullObjectModelValidator>();

builder.Services
    .AddScoped<IEmployeeRepo, EmployeeRepo>()
    .AddScoped<IAddressRepo, AddressRepo>()
    .AddScoped<IContactDetailRepo, ContactDetailRepo>();

builder.Services
    .AddScoped<IEmployeeRules, EmployeeRules>()
    .AddScoped<IAddressRules, AddressRules>()
    .AddScoped<IContactDetailRules, ContactDetailRules>();

var app = builder.Build();

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true).Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

try
{
    //Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true));

Log.Information("Starting web host");
    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
