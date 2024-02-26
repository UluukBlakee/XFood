namespace XFood.Data.Models
{
    public class CriticalFactor
    {
        public int Id { get; set; }
        public int CriterionId { get; set; }
        public Criterion? Criterion { get; set; }
        public int CheckListId { get; set; }
        public CheckList? CheckList { get; set; }
        public string? Description { get; set; }
        public int MaxPoints { get; set; }
    }
}