using AutoMapper;
using Business.Models;
using dotnet_rpg.DataProvider.DataServices;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();

        }
    }
}
