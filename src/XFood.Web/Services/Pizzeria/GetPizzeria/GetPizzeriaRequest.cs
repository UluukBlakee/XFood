using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Pizzeria.GetPizzeria
{
    public class GetPizzeriaRequest
    {
        [Required] public int Id { get; set; }
    }
}
