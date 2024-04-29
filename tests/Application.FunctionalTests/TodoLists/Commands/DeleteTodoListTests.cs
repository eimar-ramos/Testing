using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.TodoLists.Commands.DeleteTodoList;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Domain.Entities;

namespace TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.FunctionalTests.TodoLists.Commands;

using static Testing;

public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
