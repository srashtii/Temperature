using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureDomain;

namespace TemperatureInfrastructure
{
    public interface ISensorLimitRepository
    {
        public Task AddSensorLimit(SensorLimit sensorLimit);
        public Task<SensorLimit> GetSensorLimitAsync();
    }
}
