using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Domain
{
    public class TemperatureWarm : TemperatureState
    {
        public override string ToString()
        {
            return "Warm";
        }
        public TemperatureWarm(double temperature) : base(temperature) { }

    }
}
