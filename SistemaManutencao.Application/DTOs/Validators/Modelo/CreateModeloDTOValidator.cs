using FluentValidation;
using SistemaManutencao.Application.DTOs.Entities.Modelo;

namespace SistemaManutencao.Application.DTOs.Validators.Modelo
{
    public class CreateModeloDTOValidator : AbstractValidator<CreateModeloDTO>
    {
        public CreateModeloDTOValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(150).WithMessage("Nome deve ter no máximo 150 caracteres")
                .MinimumLength(2).WithMessage("Nome deve ter no mínimo 2 caracteres");
        }
    }
}
