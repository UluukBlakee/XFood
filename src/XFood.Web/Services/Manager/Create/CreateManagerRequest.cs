namespace XFoodBlazor.Web.Client.Services.Manager.Create
{
    public class CreateManagerRequest
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Telegram { get; set; }
        public string? Email { get; set; }
        public int PizzeriaId { get; set; }
        
    }
}
