using XFood.Data.Models;

namespace XFood.API.Check_List.Queries
{
    public class CheckListView
    {
        public Pizzeria? Pizzeria{ get; set; }
        public int TotalPoints { get; set; }
        public List<Criterion>? Criteria { get; set; }
        public List<CategoryFactor>? CategoryFactors { get; set; }
    }
}
