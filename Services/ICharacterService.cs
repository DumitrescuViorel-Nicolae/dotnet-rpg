using Business.Models;
using dotnet_rpg.DataProvider.DataServices;
using dotnet_rpg.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_rpg.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> Get();
        Task<ServiceResponse<GetCharacterDTO>> GetById(int id);
        Task<ServiceResponse<List<GetCharacterDTO>>> CreateNew(string name, int hitPoints, int strength, int defense, int intelligence, int classNumber);


    }
}
