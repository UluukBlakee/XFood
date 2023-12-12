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
        var q = _httpClient.BaseAddress?.Host;
        var result = await _httpClient.PostAsJsonAsync("https://localhost:7051/api/account/register", registerModel);

        if (result.IsSuccessStatusCode)
        {
            var response = await result.Content.ReadFromJsonAsync<RegisterResponse>();
            return response;
        }


        return new RegisterResponse(false, await result.Content.ReadAsStringAsync());
    }

    public async Task<LoginResponse> Login(LoginRequest loginModel)
    {
        var loginAsJson = JsonSerializer.Serialize(loginModel);
        var response = await _httpClient.PostAsync("api/account/login",
            new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
        var loginResult = JsonSerializer.Deserialize<LoginResponse>(await response.Content.ReadAsStringAsync(),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (!response.IsSuccessStatusCode)
        {
            return loginResult;
        }

        await _localStorage.SetItemAsync("authToken", loginResult.Token);
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

        return loginResult;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}