namespace XFoodBlazor.Web.Client.Services.Appeal.Create
{
    public class CreateAppealRequest
    {
        public string Email { get; set; }
        public string Description { get; set; }
        public int CheckListId { get; set; }
        public int ChecklistCriteriaId { get; set; }
    }
}
