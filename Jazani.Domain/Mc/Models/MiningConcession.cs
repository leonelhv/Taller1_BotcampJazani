using Jazani.Domain.Mc.Models;

namespace Jazani.Taller.Domain.Mc.Models
{
    public class MiningConcession
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int MineralTypeId { get; set; }
        public int OriginId { get; set; }
        public int TypeId { get; set; }
        public int SituationId { get; set; }
        public int MiningUnitId { get; set; }
        public int ConditionId { get; set; }
        public int StateManagementId { get; set; }
        public bool State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<Investment>? Investments { get; set; }
    }
}
