using XFood.API.CriticalFactorDescription.Queries;

namespace XFood.API.CriticalFactors.Commands.EditCriticalFactor
{
    public class EditCriticalFactorRequest
    {
        public int Id { get; set; }
        public List<CriticalFactorDescriptionView> Descriptions { get; set; }
    }
}
