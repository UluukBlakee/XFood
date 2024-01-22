using XFoodBlazor.Web.Client.Services.Criterion;
using XFoodBlazor.Web.Client.Services.Manager;

namespace XFoodBlazor.Web.Client.Services.Pizzeria
{
    public class PizzeriaView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public List<ManagerView>? Managers { get; set; }
        public List<CriterionView>? Criteria { get; set; }
    }
}
