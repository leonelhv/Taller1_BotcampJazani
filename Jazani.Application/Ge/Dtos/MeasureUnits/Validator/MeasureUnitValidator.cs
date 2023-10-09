using FluentValidation;
using Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits;

namespace Jazani.Application.Ge.Dtos.MeasureUnits.Validator
{
    public class MeasureUnitValidator : AbstractValidator<MeasureUnitSaveDto>
    {
        public MeasureUnitValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Symbol).NotEmpty().NotNull();
        }
    }
}
