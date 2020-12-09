using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAWProject.Repositories.DatabaseRepository;
using DAWProject.Models;

namespace DAWProject.Services.DemoService
{
    public class DemoService : IDemoService
    {
        public IDatabaseRepository _databaseRepository;
        public DemoService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public WeatherForecast GetDataBaseModelMappedByTitle(string title)
        {
            Model1 result = _databaseRepository.GetByTitle(title);
            WeatherForecast weatherForecast = new WeatherForecast
            {
                Date = DateTime.Now
            };

            if (result != null)
            {
                weatherForecast.Summary = result.Id.ToString();
            }

            return weatherForecast;
        }
    }
}
