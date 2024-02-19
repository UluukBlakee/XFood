using Microsoft.AspNetCore.Identity;

namespace XFood.API.User.Queries.GetUser
{
    public class UserView : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
    }
}
