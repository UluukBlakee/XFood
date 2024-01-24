namespace XFood.API.CriticalFactors.Commands.EditCriticalFactor
{
    public class EditCriticalFactorRequest
    {
        public int Id { get; set; }
        public int MaxPoints { get; set; }
        public string Description { get; set; }
    }
}
