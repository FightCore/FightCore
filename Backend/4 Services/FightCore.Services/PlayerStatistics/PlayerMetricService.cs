using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.Characters;
using FightCore.Models.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    public interface IPlayerMetricService : IService<PlayerMetricService>
    {
        PlayerMetricService PlayerMetricService(Player player);
    }
    public class PlayerMetricService : IPlayerMetricService
    {
        public PlayerMetric GetPlayerMetric(Player player)
        {
            CharacterPlayerStatsService characterPlayerStatsService = new CharacterPlayerStatsService();
            PlayerMetric metric = new PlayerMetric
            {
                Player = player,
                Characters = new List<Character>()
            };

            //Extra variables for calculation
            int tempPlayerId;
            List<int> characterIds = new List<int>();

            //Enumerate through Sets then Set Games to get all characters used by player
            IEnumerator<Set> setEnum = player.Sets.GetEnumerator();
            while (setEnum.MoveNext())
            {
                Set set = (Set)setEnum.Current;
                IEnumerator<SetGame> setGameEnum = set.Games.GetEnumerator();
                if (set.Player1Id == player.Id)
                    tempPlayerId = set.Player1Id;
                else
                    tempPlayerId = set.Player2Id;

                while (setGameEnum.MoveNext())
                {
                    SetGame setGame = (SetGame)setGameEnum.Current;
                    if (tempPlayerId == set.Player1Id)
                        metric.Characters.Add(setGame.Character1);
                    else
                        metric.Characters.Add(setGame.Character2);
                }
            }

            metric.CharacterPlayerStats = new List<CharacterPlayerStats>();

            //Enumerate through the characters added above and create statistics for the given player for each character
            IEnumerator<Character> characterEnum = metric.Characters.GetEnumerator();
            characterIds = new List<int>();
            while (characterEnum.MoveNext())
            {
                Character character = (Character)characterEnum.Current;

                //Avoid making statistics for the same character more than once by using list of character ids.
                if (characterIds.Contains(character.Id))
                {
                    continue;
                }
                characterIds.Add(character.Id);
                metric.CharacterPlayerStats.Add(characterPlayerStatsService.GetCharacterPlayerStats(player, character));
            }

            return metric;
        }

        public void Delete(params PlayerMetricService[] entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(PlayerMetricService entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PlayerMetricService>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public PlayerMetricService Insert(PlayerMetricService entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<PlayerMetricService> InsertAsync(PlayerMetricService entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PlayerMetricService> InsertRange(params PlayerMetricService[] entities)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PlayerMetricService>> InsertRangeAsync(params PlayerMetricService[] entities)
        {
            throw new System.NotImplementedException();
        }

        public PlayerMetricService Update(PlayerMetricService entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PlayerMetricService> UpdateRange(params PlayerMetricService[] entities)
        {
            throw new System.NotImplementedException();
        }

        PlayerMetricService IPlayerMetricService.PlayerMetricService(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}
