using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Models.Responses
{
	public class SlApiMessage
	{
		public SlApiMessage()
		{
		}

		public SlApiMessageType MessageType { get; set; } = SlApiMessageType.Information;
		public string Message { get; set; } = "Success";
	}
}