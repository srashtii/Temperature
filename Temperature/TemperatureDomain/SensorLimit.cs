namespace TemperatureDomain
{
    public class SensorLimit
    {
        private double _warm;
        public int Id { get; set; }
        public double Hot { get; set; } = 35;
        public double Cold { get; set; } = 22;
        public double Warm
        {
            get
            {
                return _warm;
            }
            set
            {
                if (value > this.Cold && value < this.Hot)
                {
                    _warm = value;
                }

            }
        }
    }
}