using System.Collections.Generic;
using FightCore.Api.Resources.Posts;

namespace FightCore.Api.Resources.Characters
{
    public class CharacterResource
    {
        public string Name { get; set; }
        
        public string ImageUrl { get; set; }
        
        public object Game { get; set; }
        
        public string Description { get; set; }
        
        public List<PostResource> Posts { get; set; }
    }
}