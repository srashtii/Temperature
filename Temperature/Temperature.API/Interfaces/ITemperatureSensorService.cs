using TemperatureDomain;

namespace Temperature.API.Interfaces
{
    public interface ITemperatureSensorService
    {
        public Task<double> GetTemperature();
        //public SensorState GetSensorState();
        public Task<IEnumerable<TemperatureRecord>> GetTemperatureHistory();
        public void SetSensorLimits();
    }
}
