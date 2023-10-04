using TemperatureDomain;

namespace Temperature.API.Interfaces
{
    public interface ITemperatureSensorService
    {
        public Task<double> GetTemperature();
        public Task<string> GetSensorStateAsync(double temp);
        public Task<IEnumerable<TemperatureRecord>> GetTemperatureHistory();
        public void SetSensorLimits();
    }
}
