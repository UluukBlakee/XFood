﻿namespace XFood.API.Models;

public record ListRequest
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}