using System.ComponentModel.DataAnnotations;

namespace XFood.API.Account.Commands.AccountRegister;
    public record AccountRegisterRequest([Required]string UserName, [Required] string Email, [Required] string Password);
