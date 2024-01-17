using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.CheckListCriteria.SetPoints
{
    public class SetPointsRequest
    {
        [Required] public int Id { get; set; }
        [Required] public int ReceivedPoints { get; set; }
    }
}
