using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFood.Data.Models
{
    public class Week
    {
        public List<OpportunitySchedule> Schedules { get; set; } = new List<OpportunitySchedule>();
    }
}
