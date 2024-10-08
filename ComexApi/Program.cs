using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pedido.AppContext;

var builder = WebApplication.CreateBuilder(args);
var pedidoConection = builder.Configuration.GetConnectionString("ConnectionStrings");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opts
    =>opts.UseMySql(pedidoConection, ServerVersion.AutoDetect(pedidoConection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Comex", Version = "v1" });
}
);

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
