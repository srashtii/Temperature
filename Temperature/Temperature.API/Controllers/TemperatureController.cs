using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Temperature.API.Interfaces;
using Temperature.API.Models;

namespace Temperature.API.Controllers
{
    [ApiController]
    [Route("api/temperature")]
    public class TemperatureController : ControllerBase
    {
        private readonly ITemperatureSensorService _temperatureSensorService;
        private readonly IMapper _mapper;

        public TemperatureController(ITemperatureSensorService temperatureSensorService, IMapper mapper)
        {
            _temperatureSensorService = temperatureSensorService ?? throw new ArgumentNullException(nameof(temperatureSensorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<IActionResult> GetTemperature()
        {

            var temperature = await _temperatureSensorService.GetTemperature();

            return Ok(temperature);
        }
        [HttpGet("geHistory")]

        public async Task<ActionResult<IEnumerable<TemperatureRecordDto>>> GetTemperatureHistory()
        {

            var temperature = await _temperatureSensorService.GetTemperatureHistory();

            return Ok(_mapper.Map<IEnumerable
                <TemperatureRecordDto>>(temperature));
        }
        [HttpGet("getSensorState")]
        public async Task<ActionResult<SensorStateDto>> GetTemperatureState()
        {

            var temperature = await _temperatureSensorService.GetTemperature();
            var state = await _temperatureSensorService.GetSensorStateAsync(temperature);
            return Ok(new SensorStateDto { State = state, Temperature = temperature });
        }
    }
}

