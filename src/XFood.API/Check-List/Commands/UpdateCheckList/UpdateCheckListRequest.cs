using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using XFood.API.Check_List.Queries;

namespace XFood.API.Check_List.Commands.UpdateCheckList
{
    public class UpdateCheckListRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int TotalPoints { get; set; }
        public int PizzeriaId { get; set; }
    };
}
