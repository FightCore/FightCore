using System.Collections.Generic;
using FightCore.Models.PlayerStatistics;
using FightCore.Models.Characters;
using System.Linq;
using FightCore.Services.Patterns;
using System.Threading.Tasks;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Service for Calculating Wins, Losses, and Total Games for players depending on the referenced entity.
    /// <see cref="WinLossRecord"/>
    /// </summary>
    public interface IWinLossRecordService
    {
        WinLossRecord GetWinLossRecordByCharacter(Player player, Character character);
    }

    public class WinLossRecordService : IWinLossRecordService
    {
        public WinLossRecord GetWinLossRecordByCharacter(Player player, Character character)
        {
            List<SetGame> games = new List<SetGame>();
            //Enumerate through player sets to retrieve set games
            foreach (Set set in player.Sets)
            {
                games.AddRange(set.Games);
            }

            return GetWinLossRecordByCharacter(player, character, games);

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
    }
}
