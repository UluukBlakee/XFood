using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XFood.API.Criterions.Commands.PatchEditCriterion
{
    public class PatchEditCriterionRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxPoints { get; set; }
        public string Section { get; set; }
    }
}
