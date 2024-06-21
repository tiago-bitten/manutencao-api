using FluentValidation;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;

namespace SistemaManutencao.Application.DTOs.Validators.Localizacoes
{
    public class CreateLocalizacaoDTOValidator : AbstractValidator<CreateLocalizacaoDTO>
    {
        public CreateLocalizacaoDTOValidator()
        {
            RuleFor(l => l.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.")
                .MinimumLength(2).WithMessage("O campo Nome deve ter no mínimo 2 caracteres.")
                .MaximumLength(150).WithMessage("O campo Nome deve ter no máximo 150 caracteres.");
        
            RuleFor(l => l.Descricao)
                .MinimumLength(2).WithMessage("O campo Descrição deve ter no mínimo 2 caracteres.")
                .MaximumLength(500).WithMessage("O campo Descrição deve ter no máximo 500 caracteres.");
        }
    }
}
