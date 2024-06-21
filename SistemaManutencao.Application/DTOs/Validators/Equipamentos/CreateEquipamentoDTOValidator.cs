using FluentValidation;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;

namespace SistemaManutencao.Application.DTOs.Validators.Equipamentos
{
    public class CreateEquipamentoDTOValidator : AbstractValidator<CreateEquipamentoDTO>
    {
        public CreateEquipamentoDTOValidator()
        {
            RuleFor(equipamento => equipamento.Nome)
                .NotEmpty().WithMessage("O nome do equipamento é obrigatório.")
                .MaximumLength(150).WithMessage("O nome do equipamento não pode exceder 100 caracteres.");

            RuleFor(equipamento => equipamento.Descricao)
                .MinimumLength(2).WithMessage("A descrição do equipamento deve ter no mínimo 2 caracteres.")
                .MaximumLength(500).WithMessage("A descrição do equipamento não pode exceder 500 caracteres.");

            RuleFor(equipamento => equipamento.NumeroDeSerie)
                .MaximumLength(100).WithMessage("O número de série do equipamento não pode exceder 100 caracteres.");
        }
    }
}
