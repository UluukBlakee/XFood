using Microsoft.AspNetCore.Http;

namespace XFoodBlazor.Web.Client.Services.Appeal.Create
{
    public class CreateAppealRequest
    {
        public string Email { get; set; }
        public string Comment { get; set; }
        public string Materials { get; set; }
        public int CheckListId { get; set; }
        public int ChecklistCriteriaId { get; set; }
    }
}
