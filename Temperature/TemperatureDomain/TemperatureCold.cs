using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Domain
{
    public class TemperatureCold : TemperatureState
    {
        public override string ToString()
        {
            return "Cold";
        }
        public TemperatureCold(double temperature) : base(temperature) { }

    }
}
