using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Domain
{
    public class TemperatureHot : TemperatureState
    {
        public override string ToString()
        {
            return "Hot";
        }
        public TemperatureHot(double temperature) : base(temperature) { }
    }
}
