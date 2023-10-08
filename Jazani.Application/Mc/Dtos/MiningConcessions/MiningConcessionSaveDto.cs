namespace Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions
{
    public class MiningConcessionSaveDto
    {

        public string? Code { get; set; }
        public string? Name { get; set; }
        public int MineralTypeId { get; set; }
        public int OriginId { get; set; }
        public int TypeId { get; set; }
        public int SituationId { get; set; }
        public int MiningUnitId { get; set; }
        public int ConditionId { get; set; }
        public int StateManagementId { get; set; }

    }
}
