using FluentValidation;
using Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes;

namespace Jazani.Application.Mc.Dtos.Investmenttypes.Validators
{
    public class InvesmenttypesValidator : AbstractValidator<InvestmenttypeSaveDto>
    {
        public InvesmenttypesValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().NotNull();
        }
    }
}
