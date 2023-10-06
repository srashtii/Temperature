using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Domain
{
    public abstract class TemperatureRule
    {
        public double limit;
        public TemperatureRule(double limit)
        {
            this.limit = limit;
        }

        public abstract TemperatureState? ResolveState(double temperature);


    }
    public class HotTemperatureRule : TemperatureRule
    {
        public HotTemperatureRule(double limit)
         : base(limit) { }

        public override TemperatureState? ResolveState(double temperature)
        {
            if (temperature >= limit)
            {
                return new TemperatureHot(temperature);
            }
            return null;
        }
    }
    public class ColdTemperatureRule : TemperatureRule
    {
        public ColdTemperatureRule(double limit) : base(limit) { }

        public override TemperatureState? ResolveState(double temperature)
        {
            if (temperature < limit)
            {
                return new TemperatureCold(temperature);
            }
            return null;
        }
    }
    public class WarmTemperatureRule : TemperatureRule
    {
        private double _limitMax;
        public WarmTemperatureRule(double limitMin, double limitMax) : base(limitMin)
        {
            _limitMax = limitMax;
        }

        public override TemperatureState? ResolveState(double temperature)
        {
            if (temperature >= limit && temperature < _limitMax)
            {
                return new TemperatureWarm(temperature);
            }
            return null;
        }
    }
}
