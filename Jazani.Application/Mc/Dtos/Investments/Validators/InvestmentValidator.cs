using FluentValidation;
using Jazani.Taller.Aplication.Mc.Dtos.Investments;

namespace Jazani.Application.Mc.Dtos.Investments.Validators
{
    public class InvestmentValidator : AbstractValidator<InvestmentSaveDto>
    {
        public InvestmentValidator()
        {
            RuleFor(x => x.AmountInvested)
                .NotEmpty().NotNull();

            RuleFor(x => x.MiningConcessionId)
                .NotEmpty().NotNull();

            RuleFor(x => x.InvestmentconceptId)
                .NotEmpty().NotNull();

            RuleFor(x => x.MeasureunitId)
                .NotEmpty().NotNull();

            RuleFor(x => x.PeriodtypeId)
                .NotEmpty().NotNull();

            RuleFor(x => x.InvestmentTypeId)
                .NotEmpty().NotNull();

            RuleFor(x => x.CurrencyTypeId)
                .NotEmpty().NotNull();

            RuleFor(x => x.HolderId)
                .NotEmpty().NotNull();

            RuleFor(x => x.DeclaredTypeId)
                .NotEmpty().NotNull();

        }
    }
}
