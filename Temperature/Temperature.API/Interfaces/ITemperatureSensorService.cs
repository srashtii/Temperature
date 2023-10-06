
using Temperature.Domain;

namespace Temperature.API.Interfaces
{
    public interface ITemperatureSensorService
    {
        public Task<double> GetTemperature(Sensor sensor);
        //public Task<string> GetSensorStateAsync(double temp);
        public Task<IEnumerable<TemperatureState>> GetTemperatureHistory();
        //public Task SetSensorLimits(SensorLimit sensorLimit);
    }
}
