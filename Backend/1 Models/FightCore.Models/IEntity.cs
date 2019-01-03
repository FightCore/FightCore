namespace FightCore.Models
{
    /// <summary>
    /// An interface to be inherited on Entity Framework entities
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets an id to identify the object using Entity Framework.
        /// </summary>
        int Id { get; set; }
    }
}
