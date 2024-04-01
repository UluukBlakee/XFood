namespace XFood.API.Appeal.Commands.Accept
{
    public class AcceptAppealRequest
    {
        public int AppealId { get; set; }
        public string? Reply { get; set; }
        public int ReceivedPoints { get; set; }
    }
}
