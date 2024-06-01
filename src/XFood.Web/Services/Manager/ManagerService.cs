using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Manager.Delete;
using XFoodBlazor.Web.Client.Services.Manager.GetList;
using XFoodBlazor.Web.Client.Services.Manager.Create;
using XFoodBlazor.Web.Client.Services.Manager.Get;

namespace XFoodBlazor.Web.Client.Services.Manager
{
    public interface IManagerService
    {
        Task<GetManagersResponse> GetManagers(GetManagersRequest managerModel);
        Task<DeleteManagersResponse> Delete(DeleteManagersRequest managerModel);
        Task<CreateManagerResponse> Create(CreateManagerRequest managerModel);
        Task<GetManagerResponse> GetManager(GetManagerRequest pizzeriaModel);
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
            //todo сделать красивее через метод расширения https://code-maze.com/how-to-create-a-url-query-string/

            var url = "manager/list?PageNumber=" + managerModel.PageNumber +
                      "&PageSize=" + managerModel.PageSize +
                      (string.IsNullOrEmpty(managerModel.SearchTerm) ? "" : "&SearchTerm=" + managerModel.SearchTerm);

            var result = await _httpClient.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetManagersResponse>();
                return response;
            }

            return new GetManagersResponse(null);
        }

        public async Task<DeleteManagersResponse> Delete(DeleteManagersRequest managerModel)
        {
            var result = await _httpClient.DeleteAsync($"manager/{managerModel.Id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<DeleteManagersResponse>();
                return response;
            }

            return new DeleteManagersResponse(false);
        }

        public async Task<CreateManagerResponse> Create(CreateManagerRequest managerModel)
        {
            var result = await _httpClient.PostAsJsonAsync("manager", managerModel);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<CreateManagerResponse>();
                return response;
            }

            return new CreateManagerResponse(false);
        }

        public async Task<GetManagerResponse> GetManager(GetManagerRequest managerModel)
        {
            var result = await _httpClient.GetAsync($"manager/{managerModel.Id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetManagerResponse>();
                return response;
            }

            return new GetManagerResponse(null);
        }
    }
}