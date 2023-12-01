namespace XFood.Data.Models
{
    public class CriticalFactor
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public CategoryFactor? Category { get; set; }
        public string? Description { get; set; }
        public int MaxPoints { get; set; }
    }
}