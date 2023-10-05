using AutoMapper;
using Temperature.API.Models;
using TemperatureDomain;

namespace Temperature.API.Profiles
{
    public class SensorLimitProfile : Profile
    {
        public SensorLimitProfile()
        {
            CreateMap<SensorLimitDto, SensorLimit>();

        }
    }
}
