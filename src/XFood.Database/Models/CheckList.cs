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
        public int TotalPoints { get; set; }
        public List<Criterion>? Criteria { get; set; }
        public List<CategoryFactor>? CategoryFactors { get; set; }
    }
}
