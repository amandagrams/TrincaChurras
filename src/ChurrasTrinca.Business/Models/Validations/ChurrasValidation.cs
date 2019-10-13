using FluentValidation;

namespace ChurrasTrinca.Business.Models.Validations
{
    public class ChurrasValidation : AbstractValidator<Churras>
    {
        public ChurrasValidation()
        {
            RuleFor(c => c.Data)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 300)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Observacao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 300)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.ValorComBebida)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.ValorSemBebida)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


        }
    }
}
