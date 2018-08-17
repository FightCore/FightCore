using FightCore_Models.Characters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore_DAL;
using FightCore_Repository.Characters;

namespace FightCore_Services.Characters
{
    public interface ICharacterService
    {
        Task<Character> GetCharacterById(int id);
        ICollection<Character> GetCharactersByName(string name);
    }
    public class CharacterService : ICharacterService
    {
        private readonly GenericRepositoryAsync<Character> _repository;
        public CharacterService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.GetRepositoryAsync<Character>();
        }
        public Task<Character> GetCharacterById(int id)
        {
            return _repository.GetCharacterById(id);
        }

        public ICollection<Character> GetCharactersByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
