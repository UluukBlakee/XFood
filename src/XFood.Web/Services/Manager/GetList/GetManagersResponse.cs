using XFoodBlazor.Web.Client.Services.Models;

namespace XFoodBlazor.Web.Client.Services.Manager.GetList
{
    public record GetManagersResponse(List<ManagerView> List) : ListResponse;
}
