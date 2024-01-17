using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFood.Data.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Telegram { get; set; }
        public string? Email { get; set; }
        public int PizzeriaId { get; set; }
        public Pizzeria? Pizzeria { get; set; }
    }
}
