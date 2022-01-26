using CleanArchitecture.Application.MediatR.WeatherForecasts.Queries.GetWeatherForecasts;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecastDto>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
