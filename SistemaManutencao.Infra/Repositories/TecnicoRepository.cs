using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class TecnicoRepository : BaseRepository<Tecnico>, ITecnicoRepository
    {
        public TecnicoRepository(SistemaManutencaoDbContext context)
            : base(context)
        {
        }
        public async Task<Tecnico?> CreateTecnicoComAcessoAsync(Tecnico tecnico, string email, string senhaHash)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var sql = @"SELECT criar_tecnico_com_usuario({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})";

                var results = await _context.Database.ExecuteSqlRawAsync(sql,
                                tecnico.Nome,
                                tecnico.Telefone,
                                tecnico.Cpf,
                                tecnico.PossuiAcesso,
                                tecnico.DataNascimento,
                                tecnico.EspecializacaoId,
                                tecnico.EmpresaId,
                                email,
                                senhaHash);

                await transaction.CommitAsync();
                
                if (results < 0)
                {
                    throw new Exception("Erro ao criar técnico com acesso");
                }

                return new Tecnico();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return null;
            }
        }
    }
}
