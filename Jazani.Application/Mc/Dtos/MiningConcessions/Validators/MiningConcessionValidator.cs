using FluentValidation;
using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions;

namespace Jazani.Application.Mc.Dtos.MiningConcessions.Validators
{
    public class MiningConcessionValidator : AbstractValidator<MiningConcessionSaveDto>
    {
        public MiningConcessionValidator()
        {

            RuleFor(x => x.Code)
                .NotEmpty().NotNull();

            RuleFor(x => x.Name)
                .NotEmpty().NotNull();

            RuleFor(x => x.MineralTypeId)
                .NotEmpty().NotNull();

            RuleFor(x => x.OriginId)
                .NotEmpty().NotNull();

            RuleFor(x => x.TypeId)
                .NotEmpty().NotNull();

            RuleFor(x => x.SituationId)
                .NotEmpty().NotNull();

            RuleFor(x => x.MiningUnitId)
                .NotEmpty().NotNull();

            RuleFor(x => x.ConditionId)
                .NotEmpty().NotNull();

            RuleFor(x => x.StateManagementId)
                .NotEmpty().NotNull();

        }
    }
}
