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
        public DateTime? StartCheck { get; set; }
        public DateTime? EndCheck { get; set; }
        public int TotalPoints { get; set; }
        public List<Criterion>? Criteria { get; set; }
        public List<CategoryFactor>? CategoryFactors { get; set; }
    }
}
