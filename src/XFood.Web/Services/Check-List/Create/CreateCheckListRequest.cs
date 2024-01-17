using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Check_List.Create
{
    public class CreateCheckListRequest
    {
        [Required] public int ManagerId { get; set; }
    }
}
