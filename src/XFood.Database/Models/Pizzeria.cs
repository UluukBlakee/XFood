namespace XFood.Data.Models
{
    public class Pizzeria
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public List<User>? Managers { get; set; }
    }
}