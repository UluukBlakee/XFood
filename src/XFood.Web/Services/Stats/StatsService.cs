using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Stats.GetList;

namespace XFoodBlazor.Web.Client.Services.Stats
{
    public interface IStatsService
    {
        Task<GetListStatsResponse> GetListStats(GetListStatsRequest statsModel);
    }

    public class StatsService : IStatsService
    {
        private readonly HttpClient _httpClient;

        public StatsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetListStatsResponse> GetListStats(GetListStatsRequest statsModel)
        {
            var result = await _httpClient.GetAsync("checkList/list");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetListStatsResponse>();
                return response;
            }
            return new GetListStatsResponse(null);
        }
    }
}
