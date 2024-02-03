using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Check_List.Create;
using XFoodBlazor.Web.Client.Services.Check_List.GetCheckList;
using XFoodBlazor.Web.Client.Services.Check_List.SetTotalPoints;

namespace XFoodBlazor.Web.Client.Services.Check_List
{
    public interface ICheckService
    {
        Task<CreateCheckListResponse> Create(CreateCheckListRequest checkListModel);
        Task<SetTotalPointsResponse> SetTotalPoints(SetTotalPointsRequest checkListModel);
        Task<GetCheckListResponse> GetCheckList(GetCheckListRequest checkListModel);
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

        public async Task<SetTotalPointsResponse> SetTotalPoints(SetTotalPointsRequest checkListModel)
        {
            var result = await _httpClient.PutAsJsonAsync($"checkList/endCheck/{checkListModel.Id}", checkListModel);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<SetTotalPointsResponse>();
                return response;
            }
            return new SetTotalPointsResponse(false);
        }
        public async Task<GetCheckListResponse> GetCheckList(GetCheckListRequest checkListModel)
        {
            var result = await _httpClient.GetAsync($"checkList/{checkListModel.Id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetCheckListResponse>();
                return response;
            }
            return new GetCheckListResponse(null);
        }
    }
}
