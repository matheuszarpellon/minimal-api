using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>(options => options.UseMySql(builder.Configuration.GetConnectionString("mysql")?.ToString(), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql")?.ToString())));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "admin@teste.com" && loginDTO.Password == "123456")
        return Results.Ok("Login efetuado com sucesso!");
    else
        return Results.BadRequest("Usuário ou senha inválidos!");
});

app.Run();
