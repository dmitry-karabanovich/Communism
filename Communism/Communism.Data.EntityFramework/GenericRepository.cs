using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Communism.Data.EntityFramework.DataBase;

namespace Communism.Data.EntityFramework
{
    public class GenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        protected internal CommunismContext Context;
        protected internal IMapper Mapper;

        protected GenericRepository(CommunismContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            _dbSet = context.Set<T>();
        }

        public virtual void Add<TDto>(TDto entityDto) where TDto : class
        {
            var entity = Mapper.Map<TDto, T>(entityDto);
            _dbSet.Add(entity);
        }

        public virtual void Update<TDto>(TDto entityDto) where TDto : class
        {
            var entity = Mapper.Map<TDto, T>(entityDto);
            _dbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete<TDto>(TDto entityDto) where TDto : class
        {
            var entity = Mapper.Map<TDto, T>(entityDto);
            _dbSet.Remove(entity);
        }
        
        public virtual TDto GetByUid<TDto>(Guid uid) where TDto : class
        {
            return Mapper.Map<T, TDto>(_dbSet.Find(uid));
        }
        
        public virtual IEnumerable<TDto> GetAll<TDto>() where TDto : class
        {
            return Mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(_dbSet.ToArray());
        }
    }
}
