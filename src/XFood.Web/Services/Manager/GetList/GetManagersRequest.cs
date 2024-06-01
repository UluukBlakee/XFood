using XFoodBlazor.Web.Client.Services.Models;

namespace XFoodBlazor.Web.Client.Services.Manager.GetList
{
    public record GetManagersRequest : ListRequest
    {
        public string SearchTerm { get; set; } = "";
    }
}