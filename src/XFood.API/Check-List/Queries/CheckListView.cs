using XFood.Data.Models;

namespace XFood.API.Check_List.Queries
{
    public class CheckListView
    {
        public int Id { get; set; }
        public int PizzeriaId { get; set; }
        public DateTime? StartCheck { get; set; }
        public DateTime? EndCheck { get; set; }
        public int TotalPoints { get; set; }
        public int ManagerId { get; set; }
        public List<ChecklistCriteria>? Criteria { get; set; }
    }
}
