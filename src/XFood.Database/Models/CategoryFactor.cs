namespace XFood.Data.Models
{
    public class CategoryFactor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ReceivedPoints { get; set; }
        public int CheckListId { get; set; }
        public CheckList? CheckList { get; set; }
        public List<CriticalFactor>? CriticalFactors { get; set; }
    }
}