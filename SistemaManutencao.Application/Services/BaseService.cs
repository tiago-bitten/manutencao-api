using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace SistemaManutencao.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> ValidateEntityAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new EntidadeNaoEncontradaException("EX10001", "EntidadeGenerica");

            return entity;
        }

        public async Task<T> ValidateEntityByEmpresaIdAsync(Guid id, Guid empresaId)
        {
            var entity = await ValidateEntityAsync(id);

            var empresaIdProperty = entity.GetType().GetProperty("EmpresaId");
            if (empresaIdProperty != null)
            {
                var empresaIdValue = empresaIdProperty.GetValue(entity) as Guid?;
                if (!empresaIdValue.HasValue || empresaIdValue.Value != empresaId)
                    throw new EntidadeNaoEncontradaException("EX10018", "EntidadeGenerica");
            }
            else
                throw new EntidadeNaoEncontradaException("EX10019", "A entidade não possui a propriedade EmpresaId.");

            return entity;
        }
    }
}
