using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.DbLogs.Queries.GetDbLogById;
using CleanArchitecture.Application.MediatR.DbLogs.Queries.GetDbLogsWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1_1
{
	[ApiController]
	[ApiVersion("1.1")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class LogsController : ApiControllerBase
	{
		public LogsController()
		{
		}

		// GET: api/<LogsController>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.1")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<DbLogDto>, object>>> GetDbLogsWithPagination(
			[FromQuery] GetDbLogsWithPaginationQuery query
		)
		{
			return await Mediator.Send(query);
		}

		// GET api/<LogsController>/5
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.1")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<DbLogDto, object>> Get(int id)
		{
			return await Mediator.Send(new GetDbLogById { Id = id });
		}
	}
}