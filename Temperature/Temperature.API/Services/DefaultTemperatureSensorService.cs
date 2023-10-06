using Temperature.API.Interfaces;
using Temperature.API.Models;
using Temperature.Domain;
using TemperatureInfrastructure;

namespace Temperature.API.Services
{
    public class DefaultTemperatureSensorService : ITemperatureSensorService
    {
        private readonly SensorRepository _sensorRepository;
        private readonly ISensorLimitRepository _sensorLimitRepository;
      
        public DefaultTemperatureSensorService(SensorRepository sensorRepository)
        {

        }

        public async Task<string> GetSensorStateAsync(double temp)
        {
            //var sensorLimit = await _sensorLimitRepository.GetSensorLimitAsync();
            //if (temp >= sensorLimit.Hot)
            //{
            //    return hot;
            //}
            //else if (temp < sensorLimit.Cold)
            //{
            //    return cold;
            //}
            //else return warm;
            throw new NotImplementedException();


        }

        public async Task<double> GetTemperature(Sensor sensor)
        {
            var temperature = sensor.GetTemperature();
            await _sensorRepository.SaveAsync(sensor);
            return temperature;
        }

        public async Task<IEnumerable<TemperatureState>> GetTemperatureHistory()
        {
            return await _sensorRepository.GetHistory();
        }

        //public async Task SetSensorLimits(SensorLimit sensorLimit)
        //{
        //    await _sensorLimitRepository.AddSensorLimit(sensorLimit);
        //}
    }
}
