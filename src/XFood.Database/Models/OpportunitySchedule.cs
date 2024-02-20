using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFood.Data.Models
{
    public class OpportunitySchedule
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public User? Expert { get; set; }
        public DateTime Day { get; set; }
        public List<Time>? WorkTime { get; set; }
    }
}
