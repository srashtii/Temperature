using Moq;
using Temperature.API.Services;
using TemperatureDomain;

using TemperatureInfrastructure;

namespace TemperatureTests
{
    [TestFixture]
    public class DefaultTemperatureSensorServiceTests
    {
        [Test]
        public async Task GetSensorStateAsync_ReturnsHot()
        {
            // Arrange
            var mockTemperatureRepository = new Mock<ITemperatureRepository>();
            var mockSensorLimitRepository = new Mock<ISensorLimitRepository>();

            var sensorLimit = new SensorLimit { Hot = 35, Cold = 22, Warm = 30 };
            mockSensorLimitRepository.Setup(repo => repo.GetSensorLimitAsync()).ReturnsAsync(sensorLimit);

            var temperature = 36; // Above hot threshold

            var temperatureService = new DefaultTemperatureSensorService(mockTemperatureRepository.Object, mockSensorLimitRepository.Object);

            // Act
            var result = await temperatureService.GetSensorStateAsync(temperature);

            // Assert
            Assert.AreEqual("hot", result);
        }

        [Test]
        public async Task GetSensorStateAsync_ReturnsCold()
        {
            // Arrange
            var mockTemperatureRepository = new Mock<ITemperatureRepository>();
            var mockSensorLimitRepository = new Mock<ISensorLimitRepository>();

            var sensorLimit = new SensorLimit { Hot = 35, Cold = 22, Warm = 30 };
            mockSensorLimitRepository.Setup(repo => repo.GetSensorLimitAsync()).ReturnsAsync(sensorLimit);

            var temperature = 20; // Below cold threshold

            var temperatureService = new DefaultTemperatureSensorService(mockTemperatureRepository.Object, mockSensorLimitRepository.Object);

            // Act
            var result = await temperatureService.GetSensorStateAsync(temperature);

            // Assert
            Assert.AreEqual("cold", result);
        }

        // Additional tests for other methods can be added here...

    }
}