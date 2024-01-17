using System.ComponentModel.DataAnnotations;

namespace XFood.API.Check_List.Commands.CreateCheckList
{
    public record CreateCheckListRequest([Required] int ManagerId);
}
