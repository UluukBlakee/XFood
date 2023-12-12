using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using XFoodBlazor.Web.Client.Services.Authorization.Login;
using XFoodBlazor.Web.Client.Services.Authorization.Register;

namespace XFoodBlazor.Web.Client.Services.Authorization;

public interface IAuthService
{
    Task<RegisterResponse> Register(RegisterRequest registerModel);

    Task<LoginResponse> Login(LoginRequest loginModel);

    Task Logout();
}

public class AuthService : IAuthService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient,
        AuthenticationStateProvider authenticationStateProvider,
        ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
    }

    public async Task<RegisterResponse> Register(RegisterRequest registerModel)
    {
        var result = await _httpClient.PostAsJsonAsync("account/register", registerModel);

        if (result.IsSuccessStatusCode)
        {
            var response = await result.Content.ReadFromJsonAsync<RegisterResponse>();
            return response;
        }


        return new RegisterResponse(false, await result.Content.ReadAsStringAsync());
    }

    public async Task<LoginResponse> Login(LoginRequest loginModel)
    {
        var result = await _httpClient.PostAsJsonAsync("account/login", loginModel);

        if (result.IsSuccessStatusCode)
        {
            var response = await result.Content.ReadFromJsonAsync<LoginResponse>();
            await _localStorage.SetItemAsync("token", response.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);
            response.IsSuccess = true;
            return response;
        }

        return new LoginResponse
        {
            IsSuccess = false,
            Error = await result.Content.ReadAsStringAsync(),
            Token = null
        };
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("token");
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}