using AutoMapper;
using Temperature.API.Models;
using TemperatureDomain;

namespace Temperature.API.Profiles
{
    public class TemperatureProfile : Profile
    {
        public TemperatureProfile()
        {
            CreateMap<TemperatureRecord, TemperatureRecordDto>();

        }
    }
}
