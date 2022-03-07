using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class TodoItemProfile : Profile
	{
		public TodoItemProfile()
		{
			CreateMap<TodoItem, TodoItemBriefDto>().ReverseMap();
		}
	}
}