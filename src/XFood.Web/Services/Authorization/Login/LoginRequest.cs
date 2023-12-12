using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Authorization.Login
{
    public class LoginRequest
    {
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
    };
}