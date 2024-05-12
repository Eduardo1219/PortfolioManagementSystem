using Domain.Schedule;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.OpenApi.Models;
using PortfolioManagementSystem.Controllers.Product.Dto;
using PortfolioManagementSystem.DomainInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<ProductValidator>(ServiceLifetime.Transient);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sistema de Gestão de Portfólio de Investimentos",
        Description = "Sistema de Gestão de Portfólio de Investimentos",
    });
});

builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddHangfire((sp, config) =>
{
    var conn = sp.GetRequiredService<IConfiguration>().GetConnectionString("Default");
    config.UseSqlServerStorage(conn);
});
builder.Services.AddHangfireServer();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard();
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var jobService = services.GetRequiredService<ISchedule>();

    RecurringJob.AddOrUpdate("PushLocation", () => jobService.SendNotification(), "0 1 * * *");
}

app.Run();
