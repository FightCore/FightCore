using System.Collections.Generic;
using FightCore.Models.PlayerStatistics;
using FightCore.Models.Characters;
using System.Linq;
using FightCore.Services.Patterns;
using System.Threading.Tasks;

namespace FightCore.Services.PlayerStatistics
{
    public interface ICharacterPlayerStatsService : IService<CharacterPlayerStats>
    {
        CharacterPlayerStats GetCharacterPlayerStats(Player player, Character character);
    }

    public class CharacterPlayerStatsService : ICharacterPlayerStatsService
    {
        public CharacterPlayerStats GetCharacterPlayerStats(Player player, Character character)
        {
            WinLossRecordService winLossRecordService = new WinLossRecordService();
            CharacterPlayerStats stats = new CharacterPlayerStats
            {
                Player = player,
                Character = character
            };
            List<SetGame> setGames = new List<SetGame>();

            //Enumerate through player sets to retrieve set games
            IEnumerator<Set> setEnum = player.Sets.GetEnumerator();
            while (setEnum.MoveNext())
            {
                Set set = (Set)setEnum.Current;
                setGames.AddRange(set.Games);
            }

            stats.WinLossRecord = winLossRecordService.GetWinLossRecordByCharacter(player, character);

            // Total games played with character by player divivded by total games played by player = character usage
            stats.CharacterUsage =
                (decimal)setGames.Count(x =>
                (x.Character1 == character && x.Set.Player1Id == player.Id)
                || (x.Character2 == character && x.Set.Player2Id == player.Id))
                / (decimal)setGames.Count();

            return stats;
        }

        public void Delete(params CharacterPlayerStats[] entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(CharacterPlayerStats entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CharacterPlayerStats>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public CharacterPlayerStats Insert(CharacterPlayerStats entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<CharacterPlayerStats> InsertAsync(CharacterPlayerStats entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CharacterPlayerStats> InsertRange(params CharacterPlayerStats[] entities)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CharacterPlayerStats>> InsertRangeAsync(params CharacterPlayerStats[] entities)
        {
            throw new System.NotImplementedException();
        }

        public CharacterPlayerStats Update(CharacterPlayerStats entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CharacterPlayerStats> UpdateRange(params CharacterPlayerStats[] entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
