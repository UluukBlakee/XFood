namespace XFoodBlazor.Web.Client.Services.Appeal
{
    public class AppealView
    {
        public int Id { get; set; }
        public int CheckListId { get; set; }
        public int ChecklistCriteriaId { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? Materials { get; set; }
        public bool IsApproved { get; set; }
    }
}
