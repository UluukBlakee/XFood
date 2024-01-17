namespace XFood.Data.Models
{
    public class Criterion
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MaxPoints { get; set; }
        public string? Section { get; set; }
        public int PizzeriaId { get; set; }
        public Pizzeria? Pizzeria { get; set; }
    }
}