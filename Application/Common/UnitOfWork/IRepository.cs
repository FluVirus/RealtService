using System.Linq.Expressions;


namespace RealtService.Application.Common.UnitOfWork;

public interface IRepository<TEntity>
    where TEntity : class
{
    TEntity? GetFirstOrDefault();
    TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>> selector);
    Task<TEntity?> GetFirstOrDefaulAsync();
    Task<TEntity?> GetFirstOrDefaulAsync(Expression<Func<TEntity, bool>> selector);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> selector);
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> selector);
    TEntity? Find(params object[] keyValues);
    Task<TEntity?> FindAsync(params object[] keyValues);
    TEntity Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void Delete(IEnumerable<TEntity> entities);
}
