using Business.Models;
using dotnet_rpg.DataProvider.DataServices;
using dotnet_rpg.Models;
using dotnet_rpg.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll() => Ok(await _characterService.Get());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int id) => Ok(await _characterService.GetById(id));

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNew(string name, int hitPoints, int strength, int defense, int intelligence, int classNumber) => 
            Ok(await _characterService.CreateNew(name, hitPoints, strength, defense, intelligence, classNumber));
    }
}
