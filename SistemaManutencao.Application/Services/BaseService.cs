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

        public async Task<T> ValidarExistenciaAsync(Guid id)
        {
            if (id == null)
                return null;

            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new EntidadeNaoEncontradaException("EX10001", "EntidadeGenerica");

            return entity;
        }
    }
}
