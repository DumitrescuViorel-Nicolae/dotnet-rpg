using Business.Models;
using dotnet_rpg.Data.DataModels;
using dotnet_rpg.DataProvider.DataServices;
using dotnet_rpg.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_rpg.Services
{
    public interface ICharacterService
    {
        Task <List<Character>> GetAll();
        Task<Character> GetById(int id);
        Task<List<Character>> CreateNew(AddCharacterDTO addCharacterDTO);
        Task<List<Character>> Update(Character updateCharacterDTO);
        Task<List<Character>> Delete (int id);
        


    }
}
