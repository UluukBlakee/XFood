using XFood.API.Models;

namespace XFood.API.Manager.Queries.GetManagersList;

public record GetManagersListRequest : ListRequest
{
    public string SearchTerm { get; set; } = "";
}