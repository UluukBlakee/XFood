using XFoodBlazor.Web.Client.Services.CheckListCriteria;
using XFoodBlazor.Web.Client.Services.CriticalFactor;
using XFoodBlazor.Web.Client.Services.Manager;
using XFoodBlazor.Web.Client.Services.Pizzeria;

namespace XFoodBlazor.Web.Client.Services.Check_List
{
    public class CheckListView
    {
        public int Id { get; set; }
        public PizzeriaView? Pizzeria { get; set; }
        public DateTime? StartCheck { get; set; }
        public DateTime? EndCheck { get; set; }
        public int TotalPoints { get; set; }
        public ManagerView? Manager { get; set; }
        public List<CheckListCriteriaView>? Criteria { get; set; }
        public List<CriticalFactorView>? CriticalFactors { get; set; }
    }
}
