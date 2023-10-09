using FluentValidation;
using Jazani.Taller.Aplication.Ge.Dtos.PeriodTypes;

namespace Jazani.Application.Ge.Dtos.PeriodTypes.Validator
{
    public class PeridoTypeValidator : AbstractValidator<PeriodTypeSaveDto>
    {
        public PeridoTypeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Time).NotEmpty().NotNull();
        }
    }
}
