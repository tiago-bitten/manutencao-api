using FluentValidation;
using SistemaManutencao.Application.DTOs.Entities.Proprietarios;

namespace SistemaManutencao.Application.DTOs.Validators.Proprietarios
{
    public class CreateProprietarioDTOValidator : AbstractValidator<CreateProprietarioDTO>
    {
        public CreateProprietarioDTOValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do proprietário é obrigatório")
                .Length(2, 150).WithMessage("O nome do proprietário deve ter entre 2 e 150 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório")
                .EmailAddress().WithMessage("O email deve ser válido");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data passada");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório")
                .Length(10, 20).WithMessage("O telefone deve ter entre 10 e 20 caracteres");
        }
    }
}
