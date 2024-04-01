namespace XFood.API.Appeal.Commands.Reject
{
    public class RejectAppealRequest
    {
        public int AppealId { get; set; }
        public string? Reply { get; set; }
    }
}
