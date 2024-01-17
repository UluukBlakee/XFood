using XFood.API.Check_List.Queries;
using XFood.API.Criterions.Queries;

namespace XFood.API.CheckListCriteria.Queries
{
    public class CheckListCriteriaView
    {
        public int Id { get; set; }
        public CriterionView? Criterion { get; set; }
        public CheckListView? CheckList { get; set; }
        public int ReceivedPoints { get; set; }
    }
}
