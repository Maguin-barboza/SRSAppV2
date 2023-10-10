using Microsoft.EntityFrameworkCore;
using SRSAppV2.Domain.Interfaces.Repositories;
using SRSAppV2.Infra.Context;
using SRSAppV2.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureContext(builder.Services);
builder.Services.AddTransient<IUserRepository, UserRepository>();

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