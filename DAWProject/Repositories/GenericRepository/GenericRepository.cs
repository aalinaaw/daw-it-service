using DAWProject.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWProject.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DawAppContext _context;
        protected readonly DbSet<TEntity> Table;
        protected GenericRepository(DawAppContext dbContext)
        {
            _context = dbContext;
            Table = _context.Set<TEntity>();
        }

        public  async Task<List<TEntity>> GetAll()
        {
            return await Table.AsNoTracking().ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAllAsQueryable()
        {
            return Table.AsQueryable();
        }

        public TEntity Create(TEntity entity)
        {
            return Table.Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return Table.Update(entity).Entity;
        }

        public TEntity Delete(TEntity entity)
        {
            return Table.Remove(entity).Entity;
        }
        public void CreateRange(IEnumerable<TEntity> entities)
        {
            Table.AddRange(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);

        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);

        }

        public async Task CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public TEntity FindById(object id)
        {
            return Table.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await Table.FindAsync(id);
        }

        public TEntity FindByIds(params object[] ids)
        {
            return Table.Find(ids[0], ids[1]);
        }
        public async Task<TEntity> FindByIdsAsync(params object[] ids)
        {
            return await Table.FindAsync(ids[0], ids[1]);
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException)
            {
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (SqlException ex)
            {
                var errorMessages = new StringBuilder();

                for (var i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                                         "Message: " + ex.Errors[i].Message + "\n" +
                                         "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                         "Source: " + ex.Errors[i].Source + "\n" +
                                         "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
            }
            return false;
        }
    }
}
