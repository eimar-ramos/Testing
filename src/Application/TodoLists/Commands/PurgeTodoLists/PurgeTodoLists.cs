using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.Common.Interfaces;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.Common.Security;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Domain.Constants;

namespace TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.TodoLists.Commands.PurgeTodoLists;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeTodoListsCommand : IRequest;

public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeTodoListsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
    {
        _context.TodoLists.RemoveRange(_context.TodoLists);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
