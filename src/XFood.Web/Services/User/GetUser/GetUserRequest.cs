using System.ComponentModel.DataAnnotations;

namespace XFoodBlazor.Web.Client.Services.User.GetUser
{
    public class GetUserRequest
    {
        [Required] public int Id { get; set; }
    }
}
