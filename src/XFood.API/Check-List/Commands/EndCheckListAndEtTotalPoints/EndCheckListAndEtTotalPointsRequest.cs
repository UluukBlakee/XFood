namespace XFood.API.Check_List.Commands.EndCheckListAndEtTotalPoints
{
    public class EndCheckListAndEtTotalPointsRequest
    {
        public int Id { get; set; }
        public int TotalPoints { get; set; }
        public DateTime? EndCheck { get; set; }
    }
}