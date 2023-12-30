using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFood.Data.Models
{
    public class ChecklistCriteria
    {
        public int Id { get; set; }
        public int CriterionId { get; set; }
        public Criterion? Criterion { get; set; }
        public int CheckListId { get; set; }
        public CheckList? CheckList { get; set; }
        public int ReceivedPoints { get; set; }
    }
}
