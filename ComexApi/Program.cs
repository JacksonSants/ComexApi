using ComexApi.Data;
using ComexApi.Models;
using ComexApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionDb = builder.Configuration.GetConnectionString("connectionDb");

builder.Services.AddDbContext<BibliotecaContext>(
    opts =>
    {
        opts.UseMySql(connectionDb, ServerVersion.AutoDetect(connectionDb));
    });
builder.Services
    .AddIdentity<Admin, IdentityRole>()
    .AddEntityFrameworkStores<BibliotecaContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<RegisterServices>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
