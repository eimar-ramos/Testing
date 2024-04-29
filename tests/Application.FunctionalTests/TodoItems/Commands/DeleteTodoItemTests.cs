﻿using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Domain.Entities;

namespace TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.FunctionalTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
