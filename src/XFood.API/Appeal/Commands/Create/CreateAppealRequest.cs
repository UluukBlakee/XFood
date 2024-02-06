namespace XFood.API.Appeal.Commands.Create
{
    public record CreateAppealRequest(string Email, string Description, int ChecklistCriteriaId, int CheckListId, string Materials);
}
