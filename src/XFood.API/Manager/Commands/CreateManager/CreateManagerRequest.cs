using System.ComponentModel.DataAnnotations;

namespace XFood.API.Manager.Commands.CreateManager
{
    public record CreateManagerRequest([Required] string FirstName,[Required] string LastName, [Required] int PizzeriaId, [Required] string? Telegram, [Required] string Email);
}
