using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureSensor;

namespace Temperature.Domain
{
    public class Sensor
    {
        private TemperatureState _state;

        private readonly ITemperatureSensorComponent _temperatureSensorComponent;
        private readonly IEnumerable<TemperatureRule> _rules;
        public Sensor(ITemperatureSensorComponent temperatureSensorComponent, IEnumerable<TemperatureRule> rules)
        {
            _temperatureSensorComponent = temperatureSensorComponent ?? throw new ArgumentNullException(nameof(temperatureSensorComponent));
            _rules = rules;
            _state = new TemperatureDefault();
        }
        public double GetTemperature()
        {
            var temp = _temperatureSensorComponent.GetTemperature();
            _state = ResolveState(temp);
            return temp;
        }
        public TemperatureState GetCurrentState()
        {
            return _state;
        }
        public void ChangeRule(TemperatureRule temperatureRule)
        {
            var rule = _rules.First(x => x.GetType() == temperatureRule.GetType());
            rule = temperatureRule;
        }
        private TemperatureState ResolveState(double temperature)
        {
            foreach (var rule in _rules)
            {
                var state = rule.ResolveState(temperature);
                if (state != null)
                {
                    return state;
                }
                continue;
            }
            throw new ArgumentOutOfRangeException(nameof(temperature));
        }
    }
}
