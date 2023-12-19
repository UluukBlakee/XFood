using XFood.Data.Models;

namespace XFood.API.Check_List.Queries
{
    public class CheckListView
    {
        public int Id { get; set; }
        public XFood.Data.Models.Pizzeria? Pizzeria{ get; set; }
        public int TotalPoints { get; set; }
        public List<Criterion>? Criteria { get; set; }
        public List<CategoryFactor>? CategoryFactors { get; set; }
    }
}
