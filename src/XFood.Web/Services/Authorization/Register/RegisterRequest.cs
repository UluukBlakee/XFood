using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Authorization.Register;

public class RegisterRequest
{
    [Required] public string UserName { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
};