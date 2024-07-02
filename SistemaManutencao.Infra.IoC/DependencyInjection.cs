using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SistemaManutencao.Application.DTOs.Mappings;
using SistemaManutencao.Application.DTOs.Validators.Modelo;
using SistemaManutencao.Application.Services;
using SistemaManutencao.Application.UseCases.Auth;
using SistemaManutencao.Application.UseCases.Categorias;
using SistemaManutencao.Application.UseCases.Empresas;
using SistemaManutencao.Application.UseCases.Equipamentos;
using SistemaManutencao.Application.UseCases.Localizacoes;
using SistemaManutencao.Application.UseCases.Manutencoes;
using SistemaManutencao.Application.UseCases.Modelos;
using SistemaManutencao.Application.UseCases.Proprietarios;
using SistemaManutencao.Application.UseCases.Tecnicos;
using SistemaManutencao.Domain.Interfaces.DapperRepositories;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;
using SistemaManutencao.Infra.Data.Constants;
using SistemaManutencao.Infra.Data.Contexts;
using SistemaManutencao.Infra.Data.DapperRepositories;
using SistemaManutencao.Infra.Data.PolicyRequirements;
using SistemaManutencao.Infra.Data.Repositories;
using System.Data;

namespace SistemaManutencao.Infra.IoC
{
    public static class DependencyInjection

    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SistemaManutencaoDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbConnection>(sp => 
            new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DatabaseCleanupService>();

            services.AddAutoMapper(typeof(CategoriaProfile));
            services.AddAutoMapper(typeof(ModeloProfile));
            services.AddAutoMapper(typeof(EquipamentoProfile));
            services.AddAutoMapper(typeof(LocalizacaoProfile));
            services.AddAutoMapper(typeof(TecnicoProfile));
            services.AddAutoMapper(typeof(EmpresaProfile));
            services.AddAutoMapper(typeof(ProprietarioProfile));
            services.AddAutoMapper(typeof(ManutencaoProfile));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IManutencaoRepository, ManutencaoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<ITecnicoRepository, TecnicoRepository>();
            services.AddScoped<IEspecializacaoRepository, EspecializacaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();

            services.AddScoped<ITecnicoDapperRepository, TecnicoDapperRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ILocalizacaoService, LocalizacaoService>();
            services.AddScoped<IManutencaoService, ManutencaoService>();
            services.AddScoped<IEquipamentoService, EquipamentoService>();
            services.AddScoped<IEspecializacaoService, EspecializacaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProprietarioService, ProprietarioService>();
            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddScoped<IAuthService, JwtTokenService>();

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<CreateCategoria>();
            services.AddScoped<GetCategoriaById>();
            services.AddScoped<GetAllCategorias>();
            services.AddScoped<UpdateCategoria>();
            services.AddScoped<DeleteCategoria>();

            services.AddScoped<CreateModelo>();
            services.AddScoped<GetModeloById>();
            services.AddScoped<GetAllModelos>();
            services.AddScoped<UpdateModelo>();
            services.AddScoped<DeleteModelo>();

            services.AddScoped<CreateEquipamento>();
            services.AddScoped<GetEquipamentoById>();
            services.AddScoped<GetAllEquipamentos>();
            services.AddScoped<UpdateEquipamento>();
            services.AddScoped<DeleteEquipamento>();

            services.AddScoped<CreateLocalizacao>();
            services.AddScoped<GetLocalizacaoById>();
            services.AddScoped<GetAllLocalizacoes>();
            services.AddScoped<UpdateLocalizacao>();
            services.AddScoped<DeleteLocalizacao>();

            services.AddScoped<CreateTecnico>();
            services.AddScoped<GetAllTecnicos>();

            services.AddScoped<CreateEmpresa>();
            services.AddScoped<GetAllEmpresas>();

            services.AddScoped<CreateProprietario>();
            services.AddScoped<GetAllProprietarios>();

            services.AddScoped<CreateManutencao>();

            services.AddScoped<Login>();

            return services;
        }

        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, UsuarioAtivoHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.UsuarioAtivo, policy =>
                    policy.Requirements.Add(new UsuarioAtivoRequirement()));
            });

            return services;
        }

        public static IServiceCollection AddControllersAndVallidators(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateModeloDTOValidator>());

            return services;
        }
    }
}
