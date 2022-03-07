using CleanArchitecture.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities
{
	[Table("DbLog")]
	public class DbLog : AuditableEntity
	{
		[Key]
		[Column("Id", TypeName = "int")]
		public int Id { get; set; }

		[Column("Message", TypeName = "nvarchar(max)")]
		[Display(Name = "Message")]
		public string Message { get; set; }

		[Column("MessageTemplate", TypeName = "nvarchar(max)")]
		[Display(Name = "MessageTemplate")]
		public string MessageTemplate { get; set; }

		[Column("Level", TypeName = "nvarchar(max)")]
		[Display(Name = "Level")]
		public string Level { get; set; }

		[Column("TimeStamp", TypeName = "datetime")]
		[Display(Name = "TimeStamp")]
		public DateTime? TimeStamp { get; set; }

		[Column("Exception", TypeName = "nvarchar(max)")]
		[Display(Name = "Exception")]
		public string Exception { get; set; }

		[Column("Properties", TypeName = "nvarchar(max)")]
		[Display(Name = "Properties")]
		public string Properties { get; set; }

		[Column("EventType", TypeName = "int")]
		[Display(Name = "EventType")]
		public int? EventType { get; set; }

		[Column("Release", TypeName = "nvarchar(32)")]
		[Display(Name = "Release")]
		[StringLength(32)]
		public string Release { get; set; }

		[Column("OsVersion", TypeName = "nvarchar(50)")]
		[Display(Name = "OsVersion")]
		[StringLength(50)]
		public string OsVersion { get; set; }

		[Column("ServerName", TypeName = "nvarchar(50)")]
		[Display(Name = "ServerName")]
		[StringLength(50)]
		public string ServerName { get; set; }

		[Column("UserName", TypeName = "nvarchar(100)")]
		[Display(Name = "UserName")]
		[StringLength(100)]
		public string UserName { get; set; }

		[Column("UserDomainName", TypeName = "nvarchar(150)")]
		[Display(Name = "UserDomainName")]
		[StringLength(150)]
		public string UserDomainName { get; set; }

		[Column("Address", TypeName = "nvarchar(150)")]
		[Display(Name = "Address")]
		[StringLength(150)]
		public string Address { get; set; }

		[Column("All_SqlColumn_Defaults", TypeName = "nvarchar(max)")]
		[Display(Name = "All_SqlColumn_Defaults")]
		public string All_SqlColumn_Defaults { get; set; }
	}
}