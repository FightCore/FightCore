using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using FightCore.Models.Characters;
using FightCore.Repositories.Characters;
using FightCore.Repositories.Patterns;
using FightCore.Services.Patterns;

namespace FightCore.Services.Characters
{
    public interface IComboService : IEntityService<Combo>
    {
        Task<List<Combo>> GetAllCombosAsync();

        Task<List<Combo>> GetCombosByGameIdAsync(int gameId);

        Task<List<Combo>> GetCombosByCharacterId(int characterId);

        Task<List<Combo>> GetCombosByNameAsync(string name);
    }

    public class ComboService : EntityService<Combo>, IComboService
    {
        private readonly IComboRepository _repository;

        public ComboService(IComboRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public override Task<Combo> FindByIdAsync(int id)
        {
            return _repository.GetComboByIdAsync(id);
        }

        public Task<List<Combo>> GetAllCombosAsync()
        {
            return _repository.GetAllCombosAsync();
        }

        public Task<List<Combo>> GetCombosByGameIdAsync(int gameId)
        {
            return _repository.GetCombosByGameIdAsync(gameId);
        }

        public Task<List<Combo>> GetCombosByCharacterId(int characterId)
        {
            return _repository.GetCombosByCharacterId(characterId);
        }

        public Task<List<Combo>> GetCombosByNameAsync(string name)
        {
            return _repository.GetCombosByNameAsync(name);
        }
    }
}
