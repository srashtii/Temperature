using Temperature.API.Interfaces;
using TemperatureDomain;
using TemperatureInfrastructure;

namespace Temperature.API.Services
{
    public class DefaultTemperatureSensorService : ITemperatureSensorService
    {
        private readonly ITemperatureRepository _temperatureRepository;

        public DefaultTemperatureSensorService(ITemperatureRepository temperatureRepository)
        {
            _temperatureRepository = temperatureRepository ?? throw new ArgumentNullException(nameof(temperatureRepository));

        }
        public Task<double> GetTemperature()
        {
            return _temperatureRepository.GetTemperature();
        }

        public async Task<IEnumerable<TemperatureRecord>> GetTemperatureHistory()
        {
            return await _temperatureRepository.GetTemperatureRecords();
        }

        public void SetSensorLimits()
        {
            throw new NotImplementedException();
        }
    }
}
