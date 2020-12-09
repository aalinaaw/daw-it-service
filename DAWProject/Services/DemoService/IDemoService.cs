using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAWProject.Services.DemoService
{
    public interface IDemoService
    {
        WeatherForecast GetDataBaseModelMappedByTitle(string title);
    }
}
