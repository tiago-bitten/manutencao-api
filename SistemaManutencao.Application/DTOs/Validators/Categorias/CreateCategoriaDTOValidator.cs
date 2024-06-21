using FluentValidation;
using SistemaManutencao.Application.DTOs.Entities.Categoria;

namespace SistemaManutencao.Application.DTOs.Validators.Categorias
{
    public class CreateCategoriaDTOValidator : AbstractValidator<CreateCategoriaDTO>
    {
        public CreateCategoriaDTOValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.")
                .MinimumLength(2).WithMessage("O campo Nome deve ter no mínimo 2 caracteres.")
                .MaximumLength(150).WithMessage("O campo Nome deve ter no máximo 150 caracteres.");
        
            RuleFor(c => c.Descricao)
                .MinimumLength(2).WithMessage("O campo Descrição deve ter no mínimo 2 caracteres.")
                .MaximumLength(500).WithMessage("O campo Descrição deve ter no máximo 500 caracteres.");
        }
    }
}
