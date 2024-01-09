using XFoodBlazor.Web.Client.Services.Pizzeria;

namespace XFoodBlazor.Web.Client.Services.Manager
{
    public class ManagerView
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public PizzeriaView? Pizzeria { get; set; }
    }
}
