using System;
using System.Linq;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Services.GenericService
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        protected GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _genericRepository.GetAllAsQueryable();
        }

        public TEntity FindById(Guid id)
        {
            return _genericRepository.FindById(id);
        }

        public TEntity Create(TEntity entity)
        {
            return _genericRepository.Create(entity);
        }

        public bool Save()
        {
            return _genericRepository.Save();
        }

        public TEntity Update(TEntity entity)
        {
            return _genericRepository.Update(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            return _genericRepository.Delete(entity);
        }
    }
}
