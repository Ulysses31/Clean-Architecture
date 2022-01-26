using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class TodoItemRecordMap : ClassMap<TodoItemRecordDto>
	{
		public TodoItemRecordMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
			Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
		}
	}
}