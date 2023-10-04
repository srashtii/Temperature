using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureDomain;

namespace TemperatureInfrastructure
{
    public class DefaultSensorLimitRepository : ISensorLimitRepository
    {
        public Task AddSensorLimit(SensorLimit sensorLimit)
        {
            throw new NotImplementedException();
        }
    }
}
