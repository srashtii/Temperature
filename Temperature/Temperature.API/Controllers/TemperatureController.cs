﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Temperature.API.Interfaces;
using Temperature.API.Models;
using Temperature.Domain;

namespace Temperature.API.Controllers
{
    [ApiController]
    [Route("api/temperature")]
    public class TemperatureController : ControllerBase
    {
        private readonly ITemperatureSensorService _temperatureSensorService;
        private readonly IMapper _mapper;
        private readonly Sensor _sensor;
        private readonly TemperatureRule _temperatureRule;

        public TemperatureController(ITemperatureSensorService temperatureSensorService, IMapper mapper, Sensor sensor, TemperatureRule temperatureRule)
        {
            _temperatureSensorService = temperatureSensorService ?? throw new ArgumentNullException(nameof(temperatureSensorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _sensor = sensor ?? throw new ArgumentNullException(nameof(sensor));
            _temperatureRule = _temperatureRule ?? throw new ArgumentNullException(nameof(temperatureRule));
        }
        [HttpGet]
        public async Task<IActionResult> GetTemperature()
        {
            return Ok(await _temperatureSensorService.GetTemperature(_sensor));
        }
        [HttpGet("get-history")]

        public async Task<ActionResult<IEnumerable<TemperatureState>>> GetTemperatureHistory()
        {
            return Ok(await _temperatureSensorService.GetTemperatureHistory());

        }
        [HttpGet("sensor-state")]
        public IActionResult GetTemperatureState()
        {

            return Ok(_sensor.GetCurrentState());

        }
        [HttpPost("sensor-max-limit")]
        public IActionResult SetSensorLimit(double maxLimit)
        {
            var rule = new HotTemperatureRule(maxLimit);
            _sensor.ChangeRule(rule);
            return NoContent();

        }
        [HttpPost("sensor-min-limit")]
        public IActionResult SetSensorMinLimit(double minLimit)
        {
            var rule = new ColdTemperatureRule(minLimit);
            _sensor.ChangeRule(rule);
            return NoContent();
        }
        [HttpPost("sensor-war-limit")]
        public IActionResult SetSensorWarmLimit(double minLimit, double maxLimit)
        {
            var rule = new WarmTemperatureRule(minLimit, maxLimit);
            _sensor.ChangeRule(rule);
            return NoContent();
        }
    }
}

