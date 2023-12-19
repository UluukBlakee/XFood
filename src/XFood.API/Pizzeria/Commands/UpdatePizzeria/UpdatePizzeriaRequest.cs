using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using XFood.API.Check_List.Queries;

namespace XFood.API.Pizzeria.Commands.UpdatePizzeria
{
    public class UpdatePizzeriaRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
    }
}
