using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Check_List.SetTotalPoints
{
    public class SetTotalPointsRequest
    {
        [Required] public int Id { get; set; }
        [Required] public double TotalPoints { get; set; }
        [Required] public DateTime EndCheck { get; set; }
        [Required] public string Status { get; set; }
    }
}
