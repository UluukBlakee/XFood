using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFood.Data.Models
{
    public class CriticalFactorDescription
    {
        public int Id { get; set; }
        public int CriticalFactorId { get; set; }
        public CriticalFactor CriticalFactor { get; set; }
        public string Description { get; set; }
    }
}
