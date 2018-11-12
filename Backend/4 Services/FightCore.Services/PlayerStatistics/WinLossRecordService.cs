using System.Collections.Generic;
using FightCore.Models.PlayerStatistics;
using FightCore.Models.Characters;
using System.Linq;

namespace FightCore.Services.PlayerStatistics
{
    public class WinLossRecordService
    {
        public static WinLossRecord GetWinLossRecordByCharacter(Player player, Character character)
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
        public static WinLossRecord GetWinLossRecordByCharacter(Player player, Character character, List<SetGame> games)
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
