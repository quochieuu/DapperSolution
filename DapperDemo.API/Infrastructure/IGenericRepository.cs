namespace DapperDemo.API.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Delete(Guid id);
        Task<int> Update(T entity);
    }
}
