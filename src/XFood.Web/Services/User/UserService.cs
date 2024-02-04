using XFoodBlazor.Web.Client.Services.User.GetUser;
using System.Net.Http.Json;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace XFoodBlazor.Web.Client.Services.User
{
    public interface IUserService
    {
        Task<GetUserResponse> GetUser(GetUserRequest userModel);
        Task<string> GetUserIdByNameAsync(string username);
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(HttpClient httpClient, UserManager<IdentityUser> userManager)
        {
            _httpClient = httpClient;
            _userManager = userManager;
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
        public async Task<string> GetUserIdByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user?.Id;
        }
    }
}
