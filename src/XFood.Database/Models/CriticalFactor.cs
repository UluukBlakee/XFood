namespace XFood.Data.Models
{
    public class CriticalFactor
    {
        public int Id { get; set; }
        public int CriterionId { get; set; }
        public Criterion? Criterion { get; set; }
        public List<CriticalFactorDescription> Descriptions { get; set; } = new List<CriticalFactorDescription>();
        public int MaxPoints { get; set; }
    }
}