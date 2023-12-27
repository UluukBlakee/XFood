using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Authorization.Register;

public class CriterionRequest
{
    [Required] public string Name { get; set; }
    [Required] public string MaxPoints { get; set; }
    [Required] public string Section { get; set; }
    [Required] public string ReceivedPoints { get; set; }
    [Required] public int CheckListId { get; set; }
};