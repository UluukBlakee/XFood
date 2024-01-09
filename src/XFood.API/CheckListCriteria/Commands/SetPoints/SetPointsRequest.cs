using System.ComponentModel.DataAnnotations;
using XFood.API.CheckListCriteria.Queries;

namespace XFood.API.CheckListCriteria.Commands.SetPoints
{
    public class SetPointsRequest
    {
        public int Id { get; set; }
        public int ReceivedPoints { get; set; }
    }
}
