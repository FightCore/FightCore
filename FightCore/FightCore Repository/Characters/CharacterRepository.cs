using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FightCore_DAL;
using FightCore_Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace FightCore_Repository.Characters
{
    public static class CharacterRepository
    {
        public static Task<Character> GetCharacterById(this GenericRepositoryAsync<Character> repository, int id)
        {
            return repository.GetById(id);
        }
    }
}
