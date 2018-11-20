using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    public interface IHeadToHeadPlayerService : IService<HeadToHeadPlayer>
    {
        HeadToHeadPlayer GetHeadToHeadPlayer(Player player);
    }
    public class HeadToHeadPlayerService : IHeadToHeadPlayerService
    {
        public HeadToHeadPlayer GetHeadToHeadPlayer(Player player)
        {
            PlayerMetricService playerMetricService = new PlayerMetricService();
            return new HeadToHeadPlayer
            {
                Id = player.Id,
                Sponsor = player.Sponsor,
                Name = player.Name,
                SmashggId = player.SmashggId,
                Media = player.Media,
                Sets = player.Sets,
                PlayerMetric = playerMetricService.GetPlayerMetric(player)
            };
        }

        public void Delete(params HeadToHeadPlayer[] entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(HeadToHeadPlayer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<HeadToHeadPlayer>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public HeadToHeadPlayer Insert(HeadToHeadPlayer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<HeadToHeadPlayer> InsertAsync(HeadToHeadPlayer entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HeadToHeadPlayer> InsertRange(params HeadToHeadPlayer[] entities)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<HeadToHeadPlayer>> InsertRangeAsync(params HeadToHeadPlayer[] entities)
        {
            throw new System.NotImplementedException();
        }

        public HeadToHeadPlayer Update(HeadToHeadPlayer entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HeadToHeadPlayer> UpdateRange(params HeadToHeadPlayer[] entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
