using Jazani.Domain.Ge.Models;
using Jazani.Domain.Soc.Models;
using Jazani.Taller.Domain.Mc.Models;

namespace Jazani.Domain.Mc.Models;
public class Investment
{
    public int Id { get; set; }
    public decimal AmountInvested { get; set; }
    public string? Description { get; set; }
    public int MiningConcessionId { get; set; }

    public int? InvestmentconceptId { get; set; }
    public int CurrencyTypeId { get; set; }
    public int? PeriodtypeId { get; set; }
    public int? MeasureunitId { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool State { get; set; }
    public int HolderId { get; set; }
    public int DeclaredTypeId { get; set; }
    public int InvestmentTypeId { get; set; }

    public virtual Holder? Holder { get; set; }
    public virtual Investmentconcept? Investmentconcept { get; set; }
    public virtual Investmenttype? Investmenttype { get; set; }

    public virtual MeasureUnit? MeasureUnit { get; set; }
    public virtual MiningConcession? MiningConcession { get; set; }
    public virtual PeriodType? PeriodType { get; set; }

}
