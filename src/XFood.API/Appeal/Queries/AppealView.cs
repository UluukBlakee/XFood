using XFood.API.CheckListCriteria.Queries;
using XFood.Data.Models;

namespace XFood.API.Appeal.Queries
{
    public class AppealView
    {
        public int Id { get; set; }
        public int CheckListId { get; set; }
        public CheckListCriteriaView ChecklistCriteria { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
        public string? Materials { get; set; }
        public bool IsApproved { get; set; }
        public string? Reply { get; set; }
        public string Status { get; set; }
        public DateTime DateApplication { get; set; }
        public DateTime DateReply { get; set; }
        public List<string>? PhotosUrl { get; set; }
    }
}
