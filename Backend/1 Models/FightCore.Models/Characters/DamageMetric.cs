namespace FightCore.Models.Characters
{
    /// <summary>
    /// A metric to indicate what damage can be done to enemy characters using a combo
    /// </summary>
    public class DamageMetric : IEntity
    {
        /// <inheritdoc cref="IEntity.Id"/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the damage the subject starts at
        /// </summary>
        public double StartDamage { get; set; }

        /// <summary>
        /// Gets or sets the damage the subject will end at
        /// </summary>
        public double EndDamage { get; set; }
    }
}
