using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureData;

using TemperatureSensor;

namespace TemperatureInfrastructure
{
    //public class DefaultSensorLimitRepository : ISensorLimitRepository
    //{
        //private readonly TemperatureContext _temperatureContext;

        //public DefaultSensorLimitRepository(TemperatureContext temperatureContext)
        //{
        //    _temperatureContext = temperatureContext ?? throw new ArgumentNullException(nameof(temperatureContext));
        //}
        //public async Task AddSensorLimit(SensorLimit sensorLimit)
        //{
        //    await _temperatureContext.AddAsync(sensorLimit);
        //    await _temperatureContext.SaveChangesAsync();
        //}

        //public async Task<SensorLimit> GetSensorLimitAsync()
        //{
        //    return await _temperatureContext.SensorLimits
        //        .OrderByDescending(x => x.Id)
        //        .LastAsync();
        //}
    //}
}
