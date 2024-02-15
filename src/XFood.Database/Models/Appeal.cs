namespace XFood.Data.Models
{
    public class Appeal
    {
        public int Id { get; set; }
        public int CheckListId { get; set; }
        public CheckList? CheckList { get; set; }
        public int ChecklistCriteriaId { get; set; }
        public ChecklistCriteria? ChecklistCriteria { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
        public string? Reply { get; set; }
        public string? Materials { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
        public DateTime DateApplication { get; set; }
        public DateTime DateReply { get; set; }
        public List<Photo>? Photos { get; set; }

    }
}
