using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    public interface IHeadToHeadService : IService<HeadToHead>
    {
        HeadToHead GetHeadToHead(Player player1, Player player2);
    }
    public class HeadToHeadService : IHeadToHeadService
    {
        public HeadToHead GetHeadToHead(Player player1, Player player2)
        {
            HeadToHeadPlayerService h2hPlayerService = new HeadToHeadPlayerService();
            HeadToHead headToHead = new HeadToHead
            {
                Player1 = h2hPlayerService.GetHeadToHeadPlayer(player1),
                Player2 = h2hPlayerService.GetHeadToHeadPlayer(player2),
                Sets = new List<Set>()
            };

            // Get all sets from player1's list of sets that have the passed player1 and player2 as players.
            headToHead.Sets.AddRange(player1.Sets.Where(x =>
            (x.Player1.Id == player1.Id && x.Player2.Id == player2.Id)
            || (x.Player1.Id == player2.Id && x.Player2.Id == player1.Id)));

            // Assign number of set wins for Player 1 and Player 2 using established shared sets
            headToHead.Player1.SetWins = headToHead.Sets.Count(x => x.Winner.Id == player1.Id && x.Loser.Id == player2.Id);
            headToHead.Player2.SetWins = headToHead.Sets.Count(x => x.Winner.Id == player2.Id && x.Loser.Id == player1.Id);

            // Assign number of game wins for Player 1 and Player 2 using established shared games
            IEnumerator<Set> setEnum = headToHead.Sets.GetEnumerator();
            while (setEnum.MoveNext())
            {
                Set set = (Set)setEnum.Current;
                headToHead.Player1.GameWins += set.Games.Count(x => x.Winner == player1.Id && x.Loser == player2.Id);
                headToHead.Player2.GameWins += set.Games.Count(x => x.Winner == player2.Id && x.Loser == player1.Id);
            }

            return headToHead;
        }

        public void Delete(params HeadToHead[] entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(HeadToHead entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<HeadToHead>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public HeadToHead Insert(HeadToHead entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<HeadToHead> InsertAsync(HeadToHead entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HeadToHead> InsertRange(params HeadToHead[] entities)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<HeadToHead>> InsertRangeAsync(params HeadToHead[] entities)
        {
            throw new System.NotImplementedException();
        }

        public HeadToHead Update(HeadToHead entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HeadToHead> UpdateRange(params HeadToHead[] entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
