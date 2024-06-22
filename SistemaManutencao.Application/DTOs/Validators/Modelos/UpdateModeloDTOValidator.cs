using FluentValidation;
using SistemaManutencao.Application.DTOs.Entities.Modelo;

namespace SistemaManutencao.Application.DTOs.Validators.Modelos
{
    public class UpdateModeloDTOValidator : AbstractValidator<UpdateModeloDTO>
    {
        public UpdateModeloDTOValidator()
        {
            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.")
                .MinimumLength(2).WithMessage("O campo Nome deve ter no mínimo 2 caracteres.")
                .MaximumLength(150).WithMessage("O campo Nome deve ter no máximo 150 caracteres.");

            RuleFor(m => m.Descricao)
                .MinimumLength(2).WithMessage("O campo Descrição deve ter no mínimo 2 caracteres.")
                .MaximumLength(500).WithMessage("O campo Descrição deve ter no máximo 500 caracteres.");
        
        }
    }
}
