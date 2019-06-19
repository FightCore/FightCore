namespace FightCore.Repositories.Patterns
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves the changes made to the current context.
        /// </summary>
        /// <returns>An integer to indicate if the save was successful.</returns>
        int SaveChanges();
    }
}
