using FluentValidation.AspNetCore;
using SistemaManutencao.API.Filters;
using SistemaManutencao.API.Middlewares;
using SistemaManutencao.Application.DTOs.Validators.Categorias;
using SistemaManutencao.Application.DTOs.Validators.Equipamentos;
using SistemaManutencao.Application.DTOs.Validators.Modelo;
using SistemaManutencao.Infra.IoC;

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
    fv.RegisterValidatorsFromAssemblyContaining<CreateModeloDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateCategoriaDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<CreateEquipamentoDTOValidator>();
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
