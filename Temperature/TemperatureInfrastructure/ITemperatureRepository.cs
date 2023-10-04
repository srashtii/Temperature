using TemperatureDomain;

namespace TemperatureInfrastructure
{
    public interface ITemperatureRepository

    {
        public Task<double> GetTemperatureAsync();
        public Task AddTemperatureAsync(double temperature);
        public Task<IEnumerable<TemperatureRecord>> GetTemperatureRecords();
    }

}