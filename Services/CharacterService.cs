using AutoMapper;
using Business.Models;
using dotnet_rpg.Data.DataModels;
using dotnet_rpg.Data.Interfaces;
using dotnet_rpg.DataProvider.DataServices;
using dotnet_rpg.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly ICharactersRepository _charactersRepository;

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper, ICharactersRepository charactersRepository)
        {
            _mapper = mapper;
            _charactersRepository = charactersRepository; // inject the characters repo
        }

        public async Task<List<Character>> CreateNew(AddCharacterDTO addCharacterDTO)
        {
            Character newCharacter = new Character 
            { Name =addCharacterDTO.Name, HitPoints = addCharacterDTO.HitPoints, Stength = addCharacterDTO.Stength, Defense = addCharacterDTO.Defense,
              Intelligence = addCharacterDTO.Intelligence, Class = addCharacterDTO.Class,
            };
            var characters = await _charactersRepository.Create(newCharacter);
            var result = (characters.Select(c=> _mapper.Map<Character>(c))).ToList();
            return result;
        }
        public async Task<List<Character>> GetAll()
        {
          
            return await _charactersRepository.GetAllCharacters();
        }

        public async Task<Character> GetById(int id)
        {
            var characters = await _charactersRepository.GetAllCharacters();
            var result =_mapper.Map<Character>(characters.FirstOrDefault(c => c.Id == id));

            return result;
        }

        public async Task<List<Character>> Update(Character updateCharacterDTO)
        {
            var characterToUpdate =  _charactersRepository.GetAllCharacters().Result.FirstOrDefault(e=> e.Id == updateCharacterDTO.Id);
            characterToUpdate.Name = updateCharacterDTO.Name;
            characterToUpdate.Stength = updateCharacterDTO.Stength;
            characterToUpdate.Defense = updateCharacterDTO.Defense;
            characterToUpdate.Intelligence = updateCharacterDTO.Intelligence;
            characterToUpdate.HitPoints = updateCharacterDTO.HitPoints;
            characterToUpdate.Class = updateCharacterDTO.Class;

            await _charactersRepository.Update(characterToUpdate);

            return await _charactersRepository.GetAllCharacters();
        }
        public Task<List<Character>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
