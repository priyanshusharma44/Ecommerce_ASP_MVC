using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce_ASPDOTNET_MVC.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(ApplicationDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
        // This line seems unnecessary, since you're calling Include in individual queries
        _db.Products.Include(u => u.Category).Include(u => u.CategoryId);
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void DeleteRange(IEnumerable<T> entity)
    {
        throw new NotImplementedException();
    }

    public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProp in includeProperties
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.FirstOrDefault();
    }

    public IEnumerable<T> GetAll(string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProp in includeProperties
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.ToList();
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }

    // New Update method
    public void Update(T entity)
    {
        // Check if the entity is already being tracked by the context
        var existingEntity = _db.Set<T>().Local.FirstOrDefault(e => EF.Property<int>(e, "Id") == EF.Property<int>(entity, "Id"));

        if (existingEntity != null)
        {
            // Detach the existing entity to prevent the conflict
            _db.Entry(existingEntity).State = EntityState.Detached;
        }

        // Mark the entity as modified to update it
        _db.Entry(entity).State = EntityState.Modified;
        _db.SaveChanges();
    }
}
