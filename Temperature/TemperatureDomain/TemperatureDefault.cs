using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Domain
{
    public class TemperatureDefault : TemperatureState
    {
        public TemperatureDefault() : base(0)
        {
        }
    }
}
