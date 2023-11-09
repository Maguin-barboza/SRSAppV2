using Microsoft.EntityFrameworkCore;
using SRSAppV2.Domain.Commands.UserCmd.AddUser;
using SRSAppV2.Domain.Interfaces.Repositories;
using SRSAppV2.Domain.Interfaces.Services;
using SRSAppV2.Infra.Context;
using SRSAppV2.Infra.Repositories;
using SRSAppV2.Infra.Services;
using SRSAppV2.Infra.UnityOfWork;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureContext(builder.Services);
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IJWTService, JWTService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddUserRequest).GetTypeInfo().Assembly));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureContext(IServiceCollection services)
{
    string connectionString;

    connectionString = "Server=DESKTOP-UNE8NQO;Database=SRSApp;Integrated Security=True;TrustServerCertificate=True;";

    services.AddDbContext<SRSAppContext>(context =>
        context.UseSqlServer(connectionString));
}