using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Authorization.Login
{
    public class LoginRequest
    {
        [Required] public string EmailOrLogin { get; set; }
        [Required] public string Password { get; set; }
    };
}