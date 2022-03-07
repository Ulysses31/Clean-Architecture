using AutoMapper.EquivalencyExpression;
using CleanArchitecture.Application.Common.Behaviours;
using CleanArchitecture.Application.Common.Models.Responses;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			//services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddAutoMapper((cfg) =>
			{
				cfg.AddCollectionMappers();
				cfg.AllowNullCollections = true;
			}, System.Reflection.Assembly.GetExecutingAssembly(), System.Reflection.Assembly.GetCallingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
			services.AddScoped(typeof(SlApiResponse<,>), typeof(SlApiResponse<,>));
			return services;
		}
	}
}