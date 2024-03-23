using AutoMapper;
using ManagerApi.Core.Entities;
using ManagerAPI.Core.Dto;


namespace Persistencia.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, Usuario>().ReverseMap();
        }
    }
}
