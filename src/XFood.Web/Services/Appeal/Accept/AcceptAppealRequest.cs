namespace XFoodBlazor.Web.Client.Services.Appeal.Accept
{
    public class AcceptAppealRequest
    {
        public int AppealId { get; set; }
        public string? Reply { get; set; }
        public int ReceivedPoints { get; set; }
    }
}
