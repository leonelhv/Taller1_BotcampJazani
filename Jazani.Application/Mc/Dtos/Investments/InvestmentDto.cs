using Jazani.Application.Soc.Dtos.Holders;
using Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits;
using Jazani.Taller.Aplication.Ge.Dtos.PeriodTypes;
using Jazani.Taller.Aplication.Mc.Dtos.Investmentconcepts;
using Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes;
using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions;

namespace Jazani.Taller.Aplication.Mc.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public decimal AmountInvested { get; set; }
        public string? Description { get; set; }
        public MiningConcessionSimpleDto? MiningConcession { get; set; }
        public InvestmentconceptSimpleDto? Investmentconcept { get; set; }
        public int CurrencyTypeId { get; set; }
        public PeriodTypeSimpleDto? PeriodType { get; set; }
        public MeasureUnitSimpleDto? MeasureUnit { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public HolderSimpleDto? Holder { get; set; }
        public int DeclaredTypeId { get; set; }
        public InvestmenttypeSimpleDto? Investmenttype { get; set; }
    }
}
