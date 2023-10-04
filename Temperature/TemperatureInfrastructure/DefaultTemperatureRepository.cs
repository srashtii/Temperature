using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureData;
using TemperatureDomain;
using TemperatureSensor;

namespace TemperatureInfrastructure
{
    public class DefaultTemperatureRepository : ITemperatureRepository
    {
        private readonly TemperatureContext _temperatureContext;
        private readonly ITemperatureSensorComponent _temperatureSensorComponentService;

        public DefaultTemperatureRepository(TemperatureContext temperatureContext, ITemperatureSensorComponent defaultTemperatureSensorService)
        {
            _temperatureContext = temperatureContext ?? throw new ArgumentNullException(nameof(temperatureContext));
            _temperatureSensorComponentService = defaultTemperatureSensorService ?? throw new ArgumentNullException(nameof(defaultTemperatureSensorService));
        }

        public async Task<double> GetTemperature()
        {
            try
            {
                var temp = _temperatureSensorComponentService.GetTemperature();
                //convert to degree celcius
                temp = (temp - 32) * 5 / 9;
                await AddTemperatureAsync(temp);
                return temp;
            }
            catch (Exception ex) { throw; }

            //throw new NotImplementedException();
        }
        public async Task AddTemperatureAsync(double temperature)
        {
            TemperatureRecord temp = new()
            {
                RecordTime = DateTime.Now,
                Temperature = temperature
            };
            _temperatureContext.Add(temp);
            await _temperatureContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TemperatureRecord>> GetTemperatureRecords()
        {
            return await _temperatureContext.TemperatureRecords.
                OrderByDescending(x => x.RecordTime)
                .Take(15).ToListAsync();
        }
    }
}
