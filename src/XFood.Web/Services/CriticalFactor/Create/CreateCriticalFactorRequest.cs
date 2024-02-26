namespace XFoodBlazor.Web.Client.Services.CriticalFactor.Create
{
    public class CreateCriticalFactorRequest
    {
        public int CriterionId { get; set; }
        public string? Description { get; set; }
        public int MaxPoints { get; set; }
        public int CheckListId { get; set; }
    }
}
