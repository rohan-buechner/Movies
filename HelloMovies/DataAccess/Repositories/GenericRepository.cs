using System;
using System.Data.Entity;
using System.Linq;
using HelloMovies.DataAccess.Interfaces;

namespace HelloMovies.DataAccess.Repositories
{

    public abstract class GenericRepository<C, T> :
        IGenericRepository<T>
        where T : class
        where C : DbContext, new()
    {        
        private C db = new C();
        protected C Context
        {
            get { return db; }
            set { db = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }
     
        public virtual IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            string usrMsg = ValidationAdd(entity);

            if (string.IsNullOrEmpty(usrMsg))
            {
                 db.Set<T>().Add(entity);
            }
            else
            {
                throw new ArgumentException(usrMsg);
            }           
        }        

        public virtual void Save()
        {
            db.SaveChanges();
        }

        public virtual string ValidationAdd(T entity)
        {
            return string.Empty;
        }
        // add other validation virtuals: edit, delete

        #region Disposing
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
                if (disposing)
                    db.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}