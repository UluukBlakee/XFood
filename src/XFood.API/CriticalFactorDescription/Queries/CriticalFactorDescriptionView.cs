using XFood.Data.Models;

namespace XFood.API.CriticalFactorDescription.Queries
{
    public class CriticalFactorDescriptionView
    {
        public int Id { get; set; }
        public int CriticalFactorId { get; set; }
        public string Description { get; set; }
    }
}
