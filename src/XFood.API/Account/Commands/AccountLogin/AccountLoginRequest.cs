using System.ComponentModel.DataAnnotations;

namespace XFood.API.Account.Commands.AccountLogin
{
    public record AccountLoginRequest([Required] string EmailOrLogin, [Required] string Password, bool RememberMe);

}
