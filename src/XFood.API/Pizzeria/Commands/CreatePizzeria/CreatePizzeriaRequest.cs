using System.ComponentModel.DataAnnotations;
using XFood.Data.Models;

namespace XFood.API.Pizzeria.Commands.CreatePizzeria
{
    public record CreatePizzeriaRequest(string Name, string Region);
}
