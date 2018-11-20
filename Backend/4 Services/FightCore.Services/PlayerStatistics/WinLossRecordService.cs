using System.Collections.Generic;
using FightCore.Models.PlayerStatistics;
using FightCore.Models.Characters;
using System.Linq;
using FightCore.Services.Patterns;
using System.Threading.Tasks;

namespace FightCore.Services.PlayerStatistics
{
    public interface IWinLossRecordService : IService<WinLossRecordService>
    {
        WinLossRecord GetWinLossRecordByCharacter(Player player, Character character);
    }
    public class WinLossRecordService : IWinLossRecordService
    {
        public WinLossRecord GetWinLossRecordByCharacter(Player player, Character character)
        {
            WinLossRecord winLossRecord = new WinLossRecord();
            //Enumerate through player sets to retrieve set games
            IEnumerator<Set> setEnum = player.Sets.GetEnumerator();
            while (setEnum.MoveNext())
            {
                Set set = (Set)setEnum.Current;
                winLossRecord.Games.AddRange(set.Games);
            }

            // Total games played with character by player
            winLossRecord.Total = winLossRecord.Games.Count(x =>
            (x.Character1 == character && x.Set.Player1Id == player.Id)
            || (x.Character2 == character && x.Set.Player2Id == player.Id));

            // Total games won with character by player
            winLossRecord.Wins = winLossRecord.Games.Count(x =>
            x.Winner == player.Id && ((x.Character1 == character && x.Set.Player1Id == player.Id)
            || (x.Character2 == character && x.Set.Player2Id == player.Id)));

            //The difference of Total - Wins = Losses
            winLossRecord.Losses = winLossRecord.Total - winLossRecord.Wins;

            return winLossRecord;
        }

        //Overload for when games are already known
        public WinLossRecord GetWinLossRecordByCharacter(Player player, Character character, List<SetGame> games)
        {
            WinLossRecord winLossRecord = new WinLossRecord();
            winLossRecord.Games = games;

            // Total games played with character by player
            winLossRecord.Total = winLossRecord.Games.Count(x =>
            (x.Character1 == character && x.Set.Player1Id == player.Id)
            || (x.Character2 == character && x.Set.Player2Id == player.Id));

            // Total games won with character by player
            winLossRecord.Wins = winLossRecord.Games.Count(x =>
            x.Winner == player.Id && ((x.Character1 == character && x.Set.Player1Id == player.Id)
            || (x.Character2 == character && x.Set.Player2Id == player.Id)));

            //The difference of Total - Wins = Losses
            winLossRecord.Losses = winLossRecord.Total - winLossRecord.Wins;

            return winLossRecord;
        }

        public void Delete(params WinLossRecordService[] entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(WinLossRecordService entity)
        {
            throw new System.NotImplementedException();
        }

        public WinLossRecordService Insert(WinLossRecordService entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<WinLossRecordService> InsertAsync(WinLossRecordService entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<WinLossRecordService> InsertRange(params WinLossRecordService[] entities)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<WinLossRecordService>> InsertRangeAsync(params WinLossRecordService[] entities)
        {
            throw new System.NotImplementedException();
        }

        public WinLossRecordService Update(WinLossRecordService entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<WinLossRecordService> UpdateRange(params WinLossRecordService[] entities)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<WinLossRecordService>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
