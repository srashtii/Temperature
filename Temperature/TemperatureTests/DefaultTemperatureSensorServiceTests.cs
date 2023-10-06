
using NSubstitute;
using Temperature.Domain;
using TemperatureSensor;
using Xunit;

namespace TemperatureTests
{

    public class DefaultTemperatureSensorServiceTests
    {
        [Fact]
        public void GetSensorStateAsync_ReturnsHot()
        {
            var mockTemperatureSensoreComponent = NSubstitute.Substitute.For<ITemperatureSensorComponent>();
            mockTemperatureSensoreComponent.GetTemperature().Returns(50);
            var rules = new List<TemperatureRule> { new HotTemperatureRule(35), new ColdTemperatureRule(22), new WarmTemperatureRule(22, 35) };
            Sensor sensor = new Sensor(mockTemperatureSensoreComponent, rules);
            sensor.GetTemperature();
            Assert.True(sensor.GetCurrentState() is TemperatureHot);
            var hotRule = rules.First(x => x.GetType() == typeof(HotTemperatureRule));
            rules.Remove(hotRule);
            rules.Add(new HotTemperatureRule(60));
            Assert.Throws<ArgumentOutOfRangeException>(() => sensor.GetTemperature());
        }
        [Fact]
        public void GetCurrentStateOfTemperature()
        {
            var mockTemperatureSensoreComponent = NSubstitute.Substitute.For<ITemperatureSensorComponent>();
            mockTemperatureSensoreComponent.GetTemperature().Returns(50);
            var rules = new List<TemperatureRule> { new HotTemperatureRule(35), new ColdTemperatureRule(22), new WarmTemperatureRule(22, 35) };
            Sensor sensor = new Sensor(mockTemperatureSensoreComponent, rules);
            sensor.GetTemperature();
            Assert.True(sensor.GetCurrentState().MeasuredTemperature == 50);
        }
        // Additional tests are remaining to be added here

    }
}