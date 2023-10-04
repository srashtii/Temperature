using Temperature.API.Interfaces;
using TemperatureDomain;
using TemperatureInfrastructure;

namespace Temperature.API.Services
{
    public class DefaultTemperatureSensorService : ITemperatureSensorService
    {
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly ISensorLimitRepository _sensorLimitRepository;
        private const string hot = "hot";
        private const string cold = "cold";
        private const string warm = "warm";
        public DefaultTemperatureSensorService(ITemperatureRepository temperatureRepository, ISensorLimitRepository sensorLimitRepository)
        {
            _temperatureRepository = temperatureRepository ?? throw new ArgumentNullException(nameof(temperatureRepository));
            _sensorLimitRepository = sensorLimitRepository ?? throw new ArgumentNullException(nameof(sensorLimitRepository));

        }

        public async Task<string> GetSensorStateAsync(double temp)
        {
            var sensorLimit = await _sensorLimitRepository.GetSensorLimitAsync();
            if (temp >= sensorLimit.Hot)
            {
                return hot;
            }
            else if (temp < sensorLimit.Cold)
            {
                return cold;
            }
            else return warm;

        }

        public async Task<double> GetTemperature()
        {
            return await _temperatureRepository.GetTemperatureAsync();
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
