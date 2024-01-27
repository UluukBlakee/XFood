namespace XFoodBlazor.Web.Client.Services.CriticalFactor.Update
{
    public class UpdateCriticalFactorRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CriterionId { get; set; }
        public int MaxPoints { get; set; }
    }
}
