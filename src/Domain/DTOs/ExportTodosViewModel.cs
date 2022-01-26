namespace CleanArchitecture.Domain.DTOs
{
	public class ExportTodosViewModel
	{
		public string FileName { get; set; }

		public string ContentType { get; set; }

		public byte[] Content { get; set; }
	}
}