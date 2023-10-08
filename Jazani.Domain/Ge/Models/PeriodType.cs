using Jazani.Domain.Mc.Models;

namespace Jazani.Taller.Domain.Ge.Models
{
    public class PeriodType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Time { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Investment>? Investments { get; set; }
    }
}
