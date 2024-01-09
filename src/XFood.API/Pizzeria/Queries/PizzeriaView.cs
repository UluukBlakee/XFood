using System.Text.Json.Serialization;
using XFood.API.Manager.Queries;

namespace XFood.API.Pizzeria.Queries
{
    public class PizzeriaView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public List<ManagerView>? Managers { get; set; }
    }

}
