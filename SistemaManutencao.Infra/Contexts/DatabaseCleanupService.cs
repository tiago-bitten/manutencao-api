using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Infra.Data.Contexts;

public class DatabaseCleanupService
{
    private readonly SistemaManutencaoDbContext _context;

    public DatabaseCleanupService(SistemaManutencaoDbContext context)
    {
        _context = context;
    }

    public async Task CleanupAndSeedDatabaseAsync()
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            await _context.Database.ExecuteSqlRawAsync("SET session_replication_role = 'replica';");

            var tables = new[]
            {
                "usuarios", "tecnicos", "ordens_servicos", "ferramentas", "pecas_usadas", "pecas",
                "localizacoes", "modelos", "manutencoes", "especializacoes", "equipamentos_pecas",
                "equipamentos", "categorias", "papeis", "empresas", "proprietarios"
            };

            foreach (var table in tables)
            {
                await _context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {table} CASCADE;");
            }

            await _context.Database.ExecuteSqlRawAsync("SET session_replication_role = 'origin';");

            var defaultOwnerId = Guid.NewGuid();
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
                INSERT INTO proprietarios (id, nome, email, cpf, data_nascimento, telefone) 
                VALUES ({defaultOwnerId}, 'Proprietario Padrao', 'proprietario@padrao.com', '12345678901', '1970-01-01', '1234567890');");

            var defaultCompanyId = Guid.NewGuid();
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
                INSERT INTO empresas (id, nome, cpf_cnpj, email, tipo_empresa, telefone, endereco, cidade, estado, cep, ativo, proprietario_id) 
                VALUES ({defaultCompanyId}, 'Empresa Padrao', '12345678000100', 'empresa@padrao.com', 'PessoaJuridica', '0987654321', 'Rua Exemplo, 123', 'Cidade Exemplo', 'EX', '12345678', true, {defaultOwnerId});");

            var defaultUserId = Guid.NewGuid();
            var senhaHash = BCrypt.Net.BCrypt.HashPassword("123456789");
            await _context.Database.ExecuteSqlInterpolatedAsync($@"
                INSERT INTO usuarios (id, email, senha_hash, ativo, tipo_usuario, empresa_id) 
                VALUES ({defaultUserId}, 'usuario@padrao.com', {senhaHash}, true, 'Funcionario', {defaultCompanyId});");

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
