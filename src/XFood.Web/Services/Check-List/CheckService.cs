using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Check_List.Create;
using XFoodBlazor.Web.Client.Services.Check_List.GetList;
using XFoodBlazor.Web.Client.Services.Check_List.SetTotalPoints;
using XFoodBlazor.Web.Client.Services.Pizzeria.GetList;

namespace XFoodBlazor.Web.Client.Services.Check_List
{
    public interface ICheckService
    {
        Task<CreateCheckListResponse> Create(CreateCheckListRequest checkListModel);
        Task<SetTotalPointsResponse> SetTotalPoints(SetTotalPointsRequest checkListModel);
        Task<GetListCheckListResponse> GetListCheckList(GetListCheckListRequest pizzeriaModel);
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

        public async Task<GetListCheckListResponse> GetListCheckList(GetListCheckListRequest pizzeriaModel)
        {
            var result = await _httpClient.GetAsync("checkList/list");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetListCheckListResponse>();
                return response;
            }
            return new GetListCheckListResponse(null);
        }
    }
}
