using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaManutencao.Application.DTOs.Mappings;
using SistemaManutencao.Application.Services;
using SistemaManutencao.Application.UseCases.Categoria;
using SistemaManutencao.Application.UseCases.Modelo;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;
using SistemaManutencao.Infra.Data.Contexts;
using SistemaManutencao.Infra.Data.Repositories;

namespace SistemaManutencao.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SistemaManutencaoDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(CategoriaProfile));
            services.AddAutoMapper(typeof(ModeloProfile));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICadastroGeralItemRepository, CadastroItemGeralRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IModeloService, ModeloService>();

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<CreateCategoria>();
            services.AddScoped<GetCategoriaById>();
            services.AddScoped<GetAllCategorias>();
            services.AddScoped<UpdateCategoria>();

            services.AddScoped<CreateModelo>();
            services.AddScoped<GetModeloById>();
            services.AddScoped<GetAllModelos>();
            services.AddScoped<UpdateModelo>();

            return services;
        }
    }
}
