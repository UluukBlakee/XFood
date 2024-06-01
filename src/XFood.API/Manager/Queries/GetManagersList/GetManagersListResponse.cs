using XFood.API.Models;

namespace XFood.API.Manager.Queries.GetManagersList
{
    public record GetManagersListResponse(List<ManagerView> List) : ListResponse;
}
