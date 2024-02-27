using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFood.Data.Models
{
    public class CheckList
    {
        public int Id { get; set; }
        public int PizzeriaId { get; set; }
        public Pizzeria? Pizzeria { get; set; }
        public DateTime? StartCheck { get; set; }
        public DateTime? EndCheck { get; set; }
        public int TotalPoints { get; set; }
        public int ManagerId { get; set; }
        public Manager? Manager { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string? Status { get; set; }
        public List<ChecklistCriteria>? Criteria { get; set; }
        public List<CriticalFactor>? CriticalFactor { get; set; }
    }
}
