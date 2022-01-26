using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Domain.DTOs
{
	public class TodoItemBriefDto : IMapFrom<TodoItem>
	{
		public int Id { get; set; }

		public int ListId { get; set; }

		public string Title { get; set; }

		public bool Done { get; set; }
	}
}