using Microsoft.AspNetCore.Identity;

namespace XFood.API.User.Queries
{
    public class UserView : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
    }
}
