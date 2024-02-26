namespace XFood.API.Appeal.Commands.Create
{
    public record CreateAppealRequest(string Email, string Comment, int ChecklistCriteriaId, int CheckListId, string materials);
}
