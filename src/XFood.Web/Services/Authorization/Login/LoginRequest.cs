using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Authorization
{
    public record LoginRequest([Required] string Email, [Required] string Password);

}
