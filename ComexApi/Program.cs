using ComexApi.Authorization;
using ComexApi.Data;
using ComexApi.Models;
using ComexApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionDb = builder.Configuration["ConnectionStrings: connectionDb"];

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
builder.Services.AddScoped<TokenService>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IdadeMinima", policy =>
        policy.AddRequirements(new IdadeMinima(18))
        );
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"])),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddSingleton<IAuthorizationHandler, IdadeAuthorization>();

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0.1",
        Title = "Api gestâo de biblioteca.",
        Description = "Api de gência e gestão de biblioteca. Ela permite a gestâo de usuários e controle de acesso, assim como o cdastro de livros e empréstimos para cliente.",
        Contact = new OpenApiContact
        {
            Name = "Suporte a DEVs",
            Email = "biblioteca@gmail.com",
            Url = new Uri("https://example.com/biblioteca@gmail.com")
        },
        License = new OpenApiLicense
        {
            Name = "GPL V3",
            Url = new Uri("https://example.com/biblioteca@gmail.com")
        },
        TermsOfService = new Uri("https://example.com/terms"),
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
