namespace Jazani.Taller.Aplication.Mc.Dtos.Investments
{
    public class InvestmentSaveDto
    {
        public decimal AmountInvested { get; set; }
        public string? Description { get; set; }
        public int MiningConcessionId { get; set; }
        public int InvestmentconceptId { get; set; }
        public int MeasureunitId { get; set; }
        public int PeriodtypeId { get; set; }
        public int InvestmentTypeId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int HolderId { get; set; }
        public int DeclaredTypeId { get; set; }
    }
}



