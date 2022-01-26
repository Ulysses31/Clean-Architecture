﻿using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.MediatR.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.Application.MediatR.TodoLists.Commands.CreateTodoList;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IntegrationTests.TodoItems.Commands
{
	using static Testing;

	public class CreateTodoItemTests : TestBase
	{
		[Test]
		public async Task ShouldRequireMinimumFields()
		{
			var command = new CreateTodoItemCommand();

			await FluentActions.Invoking(() =>
				SendAsync(command)).Should().ThrowAsync<ValidationException>();
		}

		[Test]
		public async Task ShouldCreateTodoItem()
		{
			var userId = await RunAsDefaultUserAsync();

			var listId = await SendAsync(new CreateTodoListCommand
			{
				Title = "New List"
			});

			var command = new CreateTodoItemCommand
			{
				ListId = listId,
				Title = "Tasks"
			};

			var itemId = await SendAsync(command);

			var item = await FindAsync<TodoItem>(itemId);

			item.Should().NotBeNull();
			item.ListId.Should().Be(command.ListId);
			item.Title.Should().Be(command.Title);
			item.CreatedBy.Should().Be(userId);
			item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
			item.LastModifiedBy.Should().BeNull();
			item.LastModified.Should().BeNull();
		}
	}
}