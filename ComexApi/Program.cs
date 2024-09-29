using ComexApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var produtoConnection = builder.Configuration.GetConnectionString("ProdutoConnection");

builder.Services.AddDbContext<ProdutoContext>(opts =>
    opts.UseLazyLoadingProxies().UseMySql(produtoConnection, ServerVersion.AutoDetect(produtoConnection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Comex API",
        Description = "O projeto � uma plataforma de e-commerce voltada para a venda de produtos de diferentes categorias." +
        "Ele permite o gerenciamento completo de produtos, clientes e categorias, oferecendo opera��es CRUD para cada " +
        "entidade. O sistema tamb�m permite que clientes fa�am pedidos, visualizem produtos e gerenciem seus pr�prios dados.",
        TermsOfService = new Uri("https://localhost:7118/swagger/index.html"),
        Contact = new OpenApiContact
        {
            Name = "jacksondiego@gmail.com",
            Url = new Uri("https://localhost:7118/swagger/index.html")
        },
        License = new OpenApiLicense
        {
            Name = "Documenta��o",
            Url = new Uri("https://localhost:7118/swagger/index.html")
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
