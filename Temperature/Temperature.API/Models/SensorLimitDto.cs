using System.ComponentModel.DataAnnotations;

namespace Temperature.API.Models
{
    public class SensorLimitDto
    {
        [Required(ErrorMessage = "You should provide a hot limit.")]
        public double? Hot { get; set; }
        public double? warm { get; set; }
        [Required(ErrorMessage = "You should provide a cold limit.")]
        public double? Cold { get; set; }
    }
}
