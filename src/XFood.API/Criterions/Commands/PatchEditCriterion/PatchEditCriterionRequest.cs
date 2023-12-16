using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XFood.API.Criterions.Commands.PatchEditCriterion
{
    public record PatchEditCriterionRequest(int Id, string Name, [Required] int MaxPoints, string Section, [Required] int ReceivedPoints, [Required] int CheckListId);
}
