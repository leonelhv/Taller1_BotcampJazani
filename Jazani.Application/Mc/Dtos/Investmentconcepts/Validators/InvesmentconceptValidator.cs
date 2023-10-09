using FluentValidation;
using Jazani.Taller.Aplication.Mc.Dtos.Investmentconcepts;

namespace Jazani.Application.Mc.Dtos.Investmentconcepts.Validators
{
    public class InvesmentconceptValidator : AbstractValidator<InvestmentconceptSaveDto>
    {

        public InvesmentconceptValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().NotNull();
        }
    }
}

