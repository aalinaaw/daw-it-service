using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DAWProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DAWProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("special")]
        public string[] GetSpecial()
        {
            return Summaries;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast sendObject)
        {
            if (sendObject != null)
            {
                return Ok(new
                {
                    Success = true,
                    Message = "Successfully received the object"
                });
            }

            else return BadRequest("The object is null");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] WeatherForecast nameToDelete)
        {
            ArrayList list = new ArrayList
            {
                "a1",
                "b2",
                "c3",
                "d4",
                "e5",
                "f6"
            };

            list.Remove(nameToDelete.Summary);

            return Ok(list);

        }

    }
}
