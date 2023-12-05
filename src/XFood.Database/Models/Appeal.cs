namespace XFood.Data.Models
{
    public class Appeal
    {
        public int Id { get; set; }
        public int CheckListId { get; set; }
        public CheckList? CheckList { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? Materials { get; set; }
        public bool IsApproved { get; set; }

    }
}
