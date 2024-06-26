using Dapper;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.DapperRepositories;
using System.Data;

namespace SistemaManutencao.Infra.Data.DapperRepositories
{
    public class TecnicoDapperRepository : ITecnicoDapperRepository
    {
        private readonly IDbConnection _connection;

        public TecnicoDapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Tecnico?> CreateTecnicoComAcessoAsync(Tecnico tecnico, string email, string senhaHash)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            using var transaction = _connection.BeginTransaction();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_nome", tecnico.Nome, DbType.String);
                parameters.Add("p_telefone", tecnico.Telefone, DbType.String);
                parameters.Add("p_cpf", tecnico.Cpf, DbType.String);
                parameters.Add("p_possui_acesso", tecnico.PossuiAcesso, DbType.Boolean);
                parameters.Add("p_data_nascimento", tecnico.DataNascimento, DbType.Date);
                parameters.Add("p_especializacao_id", tecnico.EspecializacaoId, DbType.Guid);
                parameters.Add("p_empresa_id", tecnico.EmpresaId, DbType.Guid);
                parameters.Add("p_email", email, DbType.String);
                parameters.Add("p_senha_hash", senhaHash, DbType.String);

                var result = await _connection.QuerySingleAsync<Guid>(
                    "SELECT criar_tecnico_com_usuario(@p_nome, @p_telefone, @p_cpf, @p_possui_acesso, @p_data_nascimento, @p_especializacao_id, @p_empresa_id, @p_email, @p_senha_hash)",
                    parameters,
                    commandType: CommandType.Text,
                    transaction: transaction);

                transaction.Commit();

                var tecnicoCriado = await _connection.QuerySingleOrDefaultAsync<Tecnico>(
                    "SELECT * FROM tecnicos WHERE id = @Id",
                    new { Id = result });

                return tecnicoCriado;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
