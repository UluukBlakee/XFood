using System.ComponentModel.DataAnnotations;

namespace XFood.API.CriticalFactors.Commands.CreateCriticalFactor
{
    public record CreateCriticalFactorRequest([Required] int MaxPoints, string? Description, [Required] int CriterionId);
}
