using System.ComponentModel.DataAnnotations;
using XFood.API.Check_List.Queries;

namespace XFood.API.Check_List.Commands.UpdateCheckList
{
    public record UpdateCheckListRequest(CheckListView CheckList);
}
