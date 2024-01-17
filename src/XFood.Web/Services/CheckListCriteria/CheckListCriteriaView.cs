using XFoodBlazor.Web.Client.Services.Check_List;
using XFoodBlazor.Web.Client.Services.Criterion;

namespace XFoodBlazor.Web.Client.Services.CheckListCriteria
{
    public class CheckListCriteriaView
    {
        public int Id { get; set; }
        public CriterionView? Criterion { get; set; }
        public CheckListView? CheckList { get; set; }
        public int ReceivedPoints { get; set; }
    }
}
