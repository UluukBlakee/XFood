using System.ComponentModel.DataAnnotations;

namespace XFood.API.Account.Commands.AccountLogin
{
    public record AccountLoginRequest([Required] string EmailOrLogin, [Required] string Password);
//=======
//    public record AccountLoginRequest([Required] string EmailOrLogin, [Required] string Password, bool RememberMe);
//>>>>>>> e33a7daa089a2bd776a19c1b3ce5031b9211330c

}
