using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Temperature.API.Interfaces;
using Temperature.API.Models;
using TemperatureDomain;

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
            try
            {
                var temperature = await _temperatureSensorService.GetTemperature();

                return Ok(temperature);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Probelm whiele rerieving the temperature from the sensor component" + ex.Message);
            }
        }
        [HttpGet("get-history")]

        public async Task<ActionResult<IEnumerable<TemperatureRecordDto>>> GetTemperatureHistory()
        {
            try
            {
                var temperature = await _temperatureSensorService.GetTemperatureHistory();

                return Ok(_mapper.Map<IEnumerable
                    <TemperatureRecordDto>>(temperature));
            }
            catch
            {
                return StatusCode(500, Enumerable.Empty<TemperatureRecordDto>());
            }
        }
        [HttpGet("sensor-state")]
        public async Task<ActionResult<SensorStateDto>> GetTemperatureState()
        {

            var temperature = await _temperatureSensorService.GetTemperature();
            var state = await _temperatureSensorService.GetSensorStateAsync(temperature);
            return Ok(new SensorStateDto { State = state, Temperature = temperature });
        }
        [HttpPost("sensor-limit")]
        public async Task<ActionResult<SensorStateDto>> SetSensorLimit(SensorLimitDto sensorLimit)
        {
            try
            {
                await _temperatureSensorService.SetSensorLimits(_mapper.Map<SensorLimit>(sensorLimit));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

