using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.Manager.Get
{
    public class GetManagerRequest
    {
        [Required] public int Id { get; set; }
    }
}
