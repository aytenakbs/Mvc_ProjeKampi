using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        Context c=new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object=c.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedValue = c.Entry(p);
            deletedValue.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }


        public void Insert(T p)
        {
            var newValue = c.Entry(p);
            newValue.State = EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedValue= c.Entry(p);
            updatedValue.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
