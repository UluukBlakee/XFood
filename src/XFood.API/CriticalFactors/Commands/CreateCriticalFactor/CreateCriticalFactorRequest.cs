using System.ComponentModel.DataAnnotations;
using XFood.API.CriticalFactorDescription.Queries;

namespace XFood.API.CriticalFactors.Commands.CreateCriticalFactor
{
    public record CreateCriticalFactorRequest([Required] int MaxPoints, List<CriticalFactorDescriptionView> Descriptions, [Required] int CriterionId, [Required] int CheckListId);
}