using System;
using System.Linq;

namespace DAWProject.Services.GenericService
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        
        TEntity FindById(Guid id);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);
        
        bool Save();
    }
}
