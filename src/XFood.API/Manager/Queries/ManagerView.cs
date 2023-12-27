namespace XFood.API.Manager.Queries
{
    public class ManagerView
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int PizzeriaId { get; set; }
        public Data.Models.Pizzeria? Pizzeria { get; set; }
    }
}
