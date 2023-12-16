using System.ComponentModel.DataAnnotations;
using XFood.Data.Models;

namespace XFood.API.Criterions.Commands.PostCreateCriterion
{
    public record PostCreateCriterionRequest(string Name, [Required] int MaxPoints, string Section, [Required] int ReceivedPoints, [Required] int CheckListId);
}