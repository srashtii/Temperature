using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temperature.Domain;

namespace TemperatureInfrastructure
{
    public class SensorRepository
    {
        public Task SaveAsync(Sensor sensor)
        {
            throw new NotImplementedException();
            //sensor.GetTemperature();
        }
        public Task<IEnumerable<TemperatureState>> GetHistory()
        {
            throw new NotImplementedException();
        }
    }
}
