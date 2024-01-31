using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Pizzeria.Create;

public class CreatePizzeriaRequest
{
    [Required] public string Name { get; set; }
    [Required] public string Region { get; set; }
};