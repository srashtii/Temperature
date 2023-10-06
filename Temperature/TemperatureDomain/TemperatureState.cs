using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Domain
{
    public abstract class TemperatureState
    {
        public double MeasuredTemperature { get; }
        public TemperatureState(double measuredTemperature)
        {
            MeasuredTemperature = measuredTemperature;
        }
    }
}
