﻿using XFood.Data.Models;

namespace XFood.API.Check_List.Queries.GetCheckListAll
{
    public record GetCheckListAllResponse(List<CheckListView> List);
}
