using Jazani.Domain.Mc.Models;

namespace Jazani.Taller.Domain.Ge.Models
{
    public class MeasureUnit
    {
        public int Id { get; set; }
        public int? MeasureUnitId { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public string? Description { get; set; }
        public string? FormulaConversion { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public virtual ICollection<Investment>? Investments { get; set; }

    }
}
