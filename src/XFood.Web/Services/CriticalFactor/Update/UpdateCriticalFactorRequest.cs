using XFoodBlazor.Web.Client.Services.CriticalFactorDescription;

namespace XFoodBlazor.Web.Client.Services.CriticalFactor.Update
{
    public class UpdateCriticalFactorRequest
    {
        public int Id { get; set; }
        public List<CriticalFactorDescriptionView> Descriptions { get; set; }
    }
}
