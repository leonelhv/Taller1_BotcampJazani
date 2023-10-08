using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Jazani.Api.Filters;
using Jazani.Api.Middlewares;
using Jazani.Application.Cores.Contexts;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(
    ".." + Path.DirectorySeparatorChar + "logapi.log",
    LogEventLevel.Warning,
    rollingInterval: RollingInterval.Day
    )
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllers(options =>
    options.Filters.Add(new ValidationFilter())
); ;

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//Route Options
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);

//Application
builder.Services.AddApplicationServices();

//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new InfrastructureAutofacModule());
        builder.RegisterModule(new ApplicationAutofacModule());
    });

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
