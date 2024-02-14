using XFood.API.CheckListCriteria.Queries;
using XFood.API.Manager.Queries;
using XFood.API.Pizzeria.Queries;
using XFood.API.User.Queries;

namespace XFood.API.Check_List.Queries
{
    public class CheckListView
    {
        public int Id { get; set; }
        public PizzeriaView? Pizzeria { get; set; }
        public DateTime? StartCheck { get; set; }
        public DateTime? EndCheck { get; set; }
        public int TotalPoints { get; set; }
        public ManagerView? Manager { get; set; }
        public int UserId { get; set; }
        public List<CheckListCriteriaView>? Criteria { get; set; }
    }
}
