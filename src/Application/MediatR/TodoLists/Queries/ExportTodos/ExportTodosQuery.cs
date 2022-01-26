using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.TodoLists.Queries.ExportTodos
{
	public class ExportTodosQuery : IRequest<ExportTodosViewModel>
	{
		public int ListId { get; set; }
	}

	public class ExportTodosQueryHandler : IRequestHandler<ExportTodosQuery, ExportTodosViewModel>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly ICsvFileBuilder _fileBuilder;

		public ExportTodosQueryHandler(
			IApplicationDbContext context,
			IMapper mapper,
			ICsvFileBuilder fileBuilder
		)
		{
			_context = context;
			_mapper = mapper;
			_fileBuilder = fileBuilder;
		}

		public async Task<ExportTodosViewModel> Handle(ExportTodosQuery request, CancellationToken cancellationToken)
		{
			var vm = new ExportTodosViewModel();

			var records = await _context.TodoItems
					.Where(t => t.ListId == request.ListId)
					.ProjectTo<TodoItemRecordDto>(_mapper.ConfigurationProvider)
					.ToListAsync(cancellationToken);

			vm.Content = _fileBuilder.BuildTodoItemsFile(records);
			vm.ContentType = "text/csv";
			vm.FileName = "TodoItems.csv";

			return await Task.FromResult(vm);
		}
	}
}