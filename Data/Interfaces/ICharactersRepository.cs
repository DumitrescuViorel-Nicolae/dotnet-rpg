using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_rpg.Data.Interfaces
{
    public interface ICharactersRepository
    {
        Task<List<Character>> GetAllCharacters();
        Task<List<Character>> CreateNew(Character character);
    }
}
