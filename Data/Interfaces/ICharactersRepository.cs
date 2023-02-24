using Business.Models;
using dotnet_rpg.DataProvider.DataServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_rpg.Data.Interfaces
{
    public interface ICharactersRepository
    {
        Task<List<Character>> GetAllCharacters();
        Task<List<Character>> CreateNew(Character character);

        Task<List<Character>> Update(Character character);
        Task Delete(GetCharacterDTO character);
    }
}
