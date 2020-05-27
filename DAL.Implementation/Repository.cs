using System.Linq;
using System.Threading.Tasks;
using DAL.Abstract;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _set;

        public Repository(TurnoverDbContext context)
        {
            _set = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _set.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _set.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }
    }
}