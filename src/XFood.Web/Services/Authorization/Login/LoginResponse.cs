namespace XFoodBlazor.Web.Client.Services.Authorization.Login;

public class LoginResponse
{
    public bool IsSuccess { get; set; }
    public string Error { get; set; }
    public string? Token { get; set; }
}