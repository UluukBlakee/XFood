using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Check_List.Create;

namespace XFoodBlazor.Web.Client.Services.Check_List
{
    public interface ICheckService
    {
        Task<CreateCheckListResponse> Create(CreateCheckListRequest checkListModel);
    }
    public class CheckService : ICheckService
    {
        private readonly HttpClient _httpClient;

        public CheckService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CreateCheckListResponse> Create(CreateCheckListRequest checkListModel)
        {
            var result = await _httpClient.PostAsJsonAsync("checkList", checkListModel);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<CreateCheckListResponse>();
                return response;
            }
            return new CreateCheckListResponse(null, await result.Content.ReadAsStringAsync());
        }
    }
}
