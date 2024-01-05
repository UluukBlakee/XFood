using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Manager.GetList;

namespace XFoodBlazor.Web.Client.Services.Manager
{
    public interface IManagerService
    {
        Task<GetManagersResponse> GetManagers(GetManagersRequest managerModel);
    }
    public class ManagerService : IManagerService
    {
        private readonly HttpClient _httpClient;
        public ManagerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetManagersResponse> GetManagers(GetManagersRequest managerModel)
        {
            var result = await _httpClient.GetAsync("manager/list");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetManagersResponse>();
                return response;
            }
            return new GetManagersResponse(null);
        }
    }
}
