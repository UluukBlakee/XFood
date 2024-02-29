using XFoodBlazor.Web.Client.Services.User.GetUser;
using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.User.GetUser;
using XFoodBlazor.Web.Client.Services.User.GetList;

namespace XFoodBlazor.Web.Client.Services.User
{
    public interface IUserService
    {
        Task<GetUserResponse> GetUser(GetUserRequest userModel);
        Task<GetUserListResponse> GetList(GetUserListRequest userModel);
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetUserListResponse> GetList(GetUserListRequest userModel)
        {
            var result = await _httpClient.GetAsync("user/list");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetUserListResponse>();
                return response;
            }
            return new GetUserListResponse(null);
        }

        public async Task<GetUserResponse> GetUser(GetUserRequest userModel)
        {
            var result = await _httpClient.GetAsync($"user/{userModel.Id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetUserResponse>();
                return response;
            }
            return new GetUserResponse(null);
        }
    }
}
