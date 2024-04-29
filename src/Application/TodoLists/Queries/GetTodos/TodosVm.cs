using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.Common.Models;

namespace TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.TodoLists.Queries.GetTodos;

public class TodosVm
{
    public IReadOnlyCollection<LookupDto> PriorityLevels { get; init; } = Array.Empty<LookupDto>();

    public IReadOnlyCollection<TodoListDto> Lists { get; init; } = Array.Empty<TodoListDto>();
}
