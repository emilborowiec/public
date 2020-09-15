namespace PonderingProgrammer.NTangle.DataAccess
{
    public interface IRepository<TEntity>
    {
        TEntity FindById(int id);
        void Add(TEntity entity);
    }
}