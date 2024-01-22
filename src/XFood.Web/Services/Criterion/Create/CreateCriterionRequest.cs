using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Criterion.Create
{
    public class CreateCriterionRequest 
    {
        public string Name { get; set; }
        [Required] public int MaxPoints { get; set; }
        public string? Section { get; set; }
        [Required] public int PizzeriaId { get; set; }   
    }
}
