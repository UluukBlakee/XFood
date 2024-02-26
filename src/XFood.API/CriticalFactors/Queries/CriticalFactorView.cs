namespace XFood.API.CriticalFactors.Queries
{
    public class CriticalFactorView
    {
        public int Id { get; set; }
        public int CriterionId { get; set; }
        public string? Description { get; set; }
        public int MaxPoints { get; set; }
        public int CheckListId { get; set; }
    }
}
