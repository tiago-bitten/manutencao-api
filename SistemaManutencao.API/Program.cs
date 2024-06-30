using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SistemaManutencao.API.Filters;
using SistemaManutencao.API.Middlewares;
using SistemaManutencao.Application.DTOs.Validators.Categorias;
using SistemaManutencao.Application.DTOs.Validators.Empresas;
using SistemaManutencao.Application.DTOs.Validators.Equipamentos;
using SistemaManutencao.Application.DTOs.Validators.Localizacoes;
using SistemaManutencao.Application.DTOs.Validators.Modelo;
using SistemaManutencao.Application.DTOs.Validators.Modelos;
using SistemaManutencao.Application.DTOs.Validators.Proprietarios;
using SistemaManutencao.Infra.IoC;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersAndVallidators();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<FiltroRespostaPadrao>();
    opt.Filters.Add<ValidationExceptionFilter>();
    opt.ModelValidatorProviders.Clear();
})
.AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<CreateCategoriaDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateCategoriaDTOValidator>();

    fv.RegisterValidatorsFromAssemblyContaining<CreateEmpresaDTOValidator>();
    
    fv.RegisterValidatorsFromAssemblyContaining<CreateEquipamentoDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateEquipamentoDTOValidator>();

    fv.RegisterValidatorsFromAssemblyContaining<CreateLocalizacaoDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateLocalizacaoDTOValidator>();

    fv.RegisterValidatorsFromAssemblyContaining<CreateModeloDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateModeloDTOValidator>();

    fv.RegisterValidatorsFromAssemblyContaining<CreateProprietarioDTOValidator>();
});

// Jwt settings
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddUseCases();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseCors(opt =>
{
    opt.AllowAnyOrigin();
    opt.AllowAnyMethod();
    opt.AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
