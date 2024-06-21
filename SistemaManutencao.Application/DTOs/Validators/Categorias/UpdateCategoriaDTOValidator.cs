using FluentValidation;
using SistemaManutencao.Application.DTOs.Entities.Categoria;

namespace SistemaManutencao.Application.DTOs.Validators.Categorias
{
    public class UpdateCategoriaDTOValidator : AbstractValidator<UpdateCategoriaDTO>
    {
        public UpdateCategoriaDTOValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(150).WithMessage("Nome deve ter no máximo 150 caracteres")
                .MinimumLength(2).WithMessage("Nome deve ter no mínimo 2 caracteres");

            RuleFor(r => r.Descricao)
                .MaximumLength(500).WithMessage("Descrição deve ter no máximo 500 caracteres")
                .MinimumLength(2).WithMessage("Descrição deve ter no mínimo 2 caracteres");
        }
    }
}
