namespace XFood.Data.Models
{
    public class CategoryFactor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ReceivedPoints { get; set; }
        public int PizzeriaId { get; set; }
        public Pizzeria? Pizzeria { get; set; }
        public List<CriticalFactor>? CriticalFactors { get; set; }
    }
}