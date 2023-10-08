namespace Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits
{
    public class MeasureUnitDto
    {
        public int Id { get; set; }
        public int? MeasureUnitId { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public string? Description { get; set; }
        public string? FormulaConversion { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
