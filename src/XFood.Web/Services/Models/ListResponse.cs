namespace XFoodBlazor.Web.Client.Services.Models;

public record ListResponse
{
    public int PageNumber { get; init; }

    public int PageSize { get; init; }

    public int TotalCount { get; init; }

    public int TotalPages { get; init; }

    public bool HasPrevious { get; init; }

    public bool HasNext { get; init; }
}