using System.Collections.Generic;
using FightCore.Models.Resources;

namespace FightCore.Models.Characters
{
    public class Character : IEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public List<Post> Posts { get; set; }
        
        public string ImageUrl { get; set; }
    }
}