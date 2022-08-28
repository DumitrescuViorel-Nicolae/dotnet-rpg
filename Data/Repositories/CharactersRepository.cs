using AutoMapper;
using Business.Models;
using dotnet_rpg.Data.Interfaces;
using dotnet_rpg.DataProvider.DataServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Data.Repositories
{
    public class CharactersRepository : ICharactersRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CharactersRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<List<Character>> CreateNew(Character character)
        {
             await _context.Characters.AddAsync(_mapper.Map<Character>(character));
             await _context.SaveChangesAsync();
            
            return await _context.Characters.ToListAsync();
        }
    }
}
