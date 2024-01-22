using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Criterion.Update
{
    public class UpdateCriterionRequest
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int MaxPoints { get; set; }
        [Required] public string Section { get; set; }
    }
}
