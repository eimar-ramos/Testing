using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Domain.Entities;

namespace TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
