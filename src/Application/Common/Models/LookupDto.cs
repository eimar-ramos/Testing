using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Domain.Entities;

namespace TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, LookupDto>();
            CreateMap<TodoItem, LookupDto>();
        }
    }
}
