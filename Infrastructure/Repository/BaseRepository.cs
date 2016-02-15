using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Context;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository
{
    public abstract class BaseRepository<TEntity> : IDisposable,
       IRepositoryAsync<TEntity> where TEntity : class, Domain.Interfaces.IEntity<int>
    {
        #region Declarations

        private readonly DatabaseContext _context;
        #endregion


        #region Ctors

        protected BaseRepository(DbContext context)
        {
            _context = context as DatabaseContext;
        }
        #endregion


        #region Implementation IRepositoryAsync

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Add(TEntity entity)
        {
            if (_context == null)
            {
                throw new NullReferenceException("Context is disposed");
            }
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Set<TEntity>().Add(entity);

            if (!_saveChanges) return;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            if (_context == null)
            {
                throw new NullReferenceException("Context is disposed");
            }
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Set<TEntity>().Add(entity);

            if (_saveChanges)
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            // TODO: check context on disposed
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
            if (_saveChanges)
            {
                if (_context.Configuration.AutoDetectChangesEnabled == false)
                {
                    _context.ChangeTracker.DetectChanges();
                }
                await _context.SaveChangesAsync();
            }
        }

     
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Entry(entity).State = EntityState.Modified;

            if (_saveChanges)
            {
                await _context.SaveChangesAsync();
            }
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id");
            }
            var entity = _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                return;
            }

            _context.Set<TEntity>().Remove(entity);
            if (!_saveChanges) return;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id");
            }
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                return;
            }

            _context.Set<TEntity>().Remove(entity);
            if (_saveChanges)
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id");
            }

            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        #endregion




        #region Implementation IUnitOfWork

        private bool _saveChanges = true;
        public bool EnableSaveChanges
        {
            get
            {
                return _saveChanges;
            }
            set
            {
                // ReSharper disable once RedundantCheckBeforeAssignment
                if (_saveChanges == value)
                {
                    return;
                }
                _saveChanges = value;
            }
        }

        public bool EnableDetectChanges
        {
            get
            {
                return _context.Configuration.AutoDetectChangesEnabled;
            }
            set
            {
                _context.Configuration.AutoDetectChangesEnabled = value;
            }
        }

        public bool EnableValidation
        {
            get
            {
                return _context.Configuration.ValidateOnSaveEnabled;
            }
            set
            {
                _context.Configuration.ValidateOnSaveEnabled = value;
            }
        }

        public async Task SaveChangesAsync()
        {
            if (_context.Configuration.AutoDetectChangesEnabled == false)
            {
                _context.ChangeTracker.DetectChanges();
            }

            await _context.SaveChangesAsync();
        }
        #endregion


        #region Implementation IDisposable

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }

        #endregion
    }
}
