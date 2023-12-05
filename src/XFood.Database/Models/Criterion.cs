namespace XFood.Data.Models
{
    public class Criterion
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MaxPoints { get; set; }
        public string? Section { get; set; }
        public int ReceivedPoints { get; set; }
        public int CheckListId { get; set; }
        public CheckList? CheckList { get; set; }
    }
}