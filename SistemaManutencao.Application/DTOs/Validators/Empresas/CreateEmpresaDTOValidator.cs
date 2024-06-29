using FluentValidation;
using SistemaManutencao.Application.DTOs.Entities.Empresas;

namespace SistemaManutencao.Application.DTOs.Validators.Empresas
{
    public class CreateEmpresaDTOValidator : AbstractValidator<CreateEmpresaDTO>
    {
        public CreateEmpresaDTOValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome da empresa é obrigatório")
                .Length(2, 150).WithMessage("O nome da empresa deve ter entre 2 e 150 caracteres");

            RuleFor(x => x.CpfCnpj)
                .NotEmpty().WithMessage("O CPF/CNPJ é obrigatório")
                .Length(11, 14).WithMessage("O CPF/CNPJ deve ter entre 11 e 14 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório")
                .EmailAddress().WithMessage("O email deve ser válido");

            RuleFor(x => x.TipoEmpresa)
                .IsInEnum().WithMessage("O tipo de empresa deve ser válido");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório")
                .Length(10, 20).WithMessage("O telefone deve ter entre 10 e 20 caracteres");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório")
                .Length(2, 150).WithMessage("O endereço deve ter entre 2 e 150 caracteres");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("A cidade é obrigatória")
                .Length(2, 100).WithMessage("A cidade deve ter entre 2 e 100 caracteres");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("O estado é obrigatório")
                .Length(2).WithMessage("O estado deve ter 2 caracteres");

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("O CEP é obrigatório")
                .Length(8).WithMessage("O CEP deve ter 8 caracteres");

            RuleFor(x => x.ProprietarioId)
                .NotEmpty().WithMessage("O ID do proprietário é obrigatório");
        }
    }
}
