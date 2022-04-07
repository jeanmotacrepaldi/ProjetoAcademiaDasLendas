using API.Contexto;
using API.Interface;
using API.Models;
using API.Repositorio;
using API.Service;
using API.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
builder.Services.AddScoped<IAnimalRepositorio, AnimalRepositorio>();
builder.Services.AddScoped<ICargoRepositorio, CargoRepositorio>();
builder.Services.AddScoped<ICasaRepositorio, CasaRepositorio>();
builder.Services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();
builder.Services.AddScoped<IPersonagemRepositorio, PersonagemRepositorio>();
builder.Services.AddScoped<IRacaRepositorio, RacaRepositorio>();
builder.Services.AddScoped<ITipoAnimalRepositorio, TipoAnimalRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddDbContext<AcademiaContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseInMemoryDatabase(nameof(AcademiaContext));
    else
        options.UseSqlServer(builder.Configuration.GetConnectionString("Dev"));
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFromAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true);
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Digite SOMENTE o token abaixo.",
        Name = "Autorização",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
});

Settings.Instance.Secret = builder.Configuration["Secret"];

var key = Encoding.ASCII.GetBytes(Settings.Instance.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
        .WithOrigins("http://localhost:8080")
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseCors("AllowFromAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
