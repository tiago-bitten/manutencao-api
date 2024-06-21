using FluentValidation;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;

namespace SistemaManutencao.Application.DTOs.Validators.Equipamentos
{
    public class UpdateEquipamentoDTOValidator : AbstractValidator<UpdateEquipamentoDTO>
    {
        public UpdateEquipamentoDTOValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.")
                .MaximumLength(150).WithMessage("O campo Nome não pode ter mais de 150 caracteres.");

            RuleFor(e => e.Descricao)
                .MinimumLength(2).WithMessage("O campo Descrição deve ter no mínimo 2 caracteres.")
                .MaximumLength(500).WithMessage("O campo Descrição não pode ter mais de 500 caracteres.");

            RuleFor(e => e.NumeroDeSerie)
                .MinimumLength(2).WithMessage("O campo Número de Série deve ter no mínimo 2 caracteres.")
                .MaximumLength(100).WithMessage("O campo Número de Série não pode ter mais de 100 caracteres.");
        }
    }
}
