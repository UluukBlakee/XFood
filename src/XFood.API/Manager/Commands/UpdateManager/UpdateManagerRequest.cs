using System.Text.Json.Serialization;

namespace XFood.API.Manager.Commands.UpdateManager
{
    public class UpdateManagerRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int PizzeriaId { get; set; }
    }
}
