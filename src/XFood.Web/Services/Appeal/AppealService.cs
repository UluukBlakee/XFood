using System.Net.Http;
using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Appeal.Create;
using XFoodBlazor.Web.Client.Services.Appeal.Delete;
using XFoodBlazor.Web.Client.Services.Appeal.GetAppeal;
using XFoodBlazor.Web.Client.Services.Appeal.GetListAppeals;

namespace XFoodBlazor.Web.Client.Services.Appeal
{
    public interface IAppealService
    {
        Task<CreateAppealResponse> Create(CreateAppealRequest appealModel);
        Task<DeleteAppealResponse> Delete(DeleteAppealRequest appealModel);
        Task<GetAppealResponse> GetAppeal(GetAppealRequest appealModel);
        Task<GetListAppealsResponse> GetListAppeals(GetListAppealsRequest appealModel);
    }
    public class AppealService : IAppealService
    {
        private readonly HttpClient _httpClient;

        public AppealService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CreateAppealResponse> Create(CreateAppealRequest appealModel)
        {
            var result = await _httpClient.PostAsJsonAsync("appeal", appealModel);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<CreateAppealResponse>();
                return response;
            }
            return new CreateAppealResponse(0);
        }

        public async Task<DeleteAppealResponse> Delete(DeleteAppealRequest appealModel)
        {
            var result = await _httpClient.DeleteAsync($"appeal/{appealModel.Id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<DeleteAppealResponse>();
                return response;
            }
            return new DeleteAppealResponse(false);
        }

        public async Task<GetAppealResponse> GetAppeal(GetAppealRequest appealModel)
        {
            var result = await _httpClient.GetAsync($"appeal/{appealModel.Id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetAppealResponse>();
                return response;
            }
            return new GetAppealResponse(null);
        }

        public async Task<GetListAppealsResponse> GetListAppeals(GetListAppealsRequest appealModel)
        {
            var result = await _httpClient.GetAsync("appeal/list");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetListAppealsResponse>();
                return response;
            }
            return new GetListAppealsResponse(null);
        }
    }
}
