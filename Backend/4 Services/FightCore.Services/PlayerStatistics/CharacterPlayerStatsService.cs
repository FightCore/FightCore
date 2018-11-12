using System.Collections.Generic;
using FightCore.Models.PlayerStatistics;
using FightCore.Models.Characters;
using System.Linq;

namespace FightCore.Services.PlayerStatistics
{
    public class CharacterPlayerStatsService
    {

        public static CharacterPlayerStats GetCharacterPlayerStats(Player player, Character character)
        {
            CharacterPlayerStats stats = new CharacterPlayerStats();
            stats.Player = player;
            stats.Character = character;
            List<SetGame> setGames = new List<SetGame>();

            //Enumerate through player sets to retrieve set games
            IEnumerator<Set> setEnum = player.Sets.GetEnumerator();
            while (setEnum.MoveNext())
            {
                Set set = (Set)setEnum.Current;
                setGames.AddRange(set.Games);
            }

            stats.WinLossRecord = WinLossRecordService.GetWinLossRecordByCharacter(player, character);

            // Total games played with character by player divivded by total games played by player = character usage
            stats.CharacterUsage =
                (decimal)setGames.Count(x =>
                (x.Character1 == character && x.Set.Player1Id == player.Id)
                || (x.Character2 == character && x.Set.Player2Id == player.Id))
                / (decimal)setGames.Count();

            return stats;
        }

    }
}
