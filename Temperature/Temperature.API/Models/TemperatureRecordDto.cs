using TemperatureDomain;

namespace Temperature.API.Models
{
    public class TemperatureRecordDto
    {

        public double Temperature { get; set; }
        public DateTime RecordTime { get; set; }
        //public Sensor SensorState { get; set; }

    }
}
