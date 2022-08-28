using AutoMapper;
using Business.Models;
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

        public async Task<ServiceResponse<List<GetCharacterDTO>>> CreateNew(string name, int hitPoints, int strength, int defense, int intelligence, int classNumber)
        {
            ServiceResponse<List<GetCharacterDTO>> serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            Character newCharacter = new Character { Name = name, HitPoints = hitPoints, Stength = strength, Defense = defense, Intelligence = intelligence, Class = (RpgClass)classNumber };
            var characters = await _charactersRepository.CreateNew(newCharacter);
            serviceResponse.Data = (characters.Select(c=> _mapper.Map<GetCharacterDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> Get()
        {
            ServiceResponse<List<GetCharacterDTO>> serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            List<Character> dbCharacters = await _charactersRepository.GetAllCharacters();
            serviceResponse.Data = (dbCharacters.Select(c=>_mapper.Map<GetCharacterDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetById(int id)
        {
            ServiceResponse<GetCharacterDTO> serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var characters = await _charactersRepository.GetAllCharacters();
            serviceResponse.Data =_mapper.Map<GetCharacterDTO>(characters.FirstOrDefault(c => c.Id == id));

            return serviceResponse;
        }
    }
}
