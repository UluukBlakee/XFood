using XFood.API.Pizzeria.Queries;

namespace XFood.API.Manager.Queries
{
    public class ManagerView
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Telegram { get; set; }
        public string? Email { get; set; }
        public PizzeriaView? Pizzeria { get; set; }
    }
}
