using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSensor
{
    public class DefaultTemperatureSensorComponentService : ITemperatureSensorComponent
    {
        public double GetTemperature()
        {
            var random = new Random();
            return random.NextDouble();
        }
    }
}
