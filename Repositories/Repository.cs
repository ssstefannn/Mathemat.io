using Mathemat.io.Data;
using Mathematio.Repositories.Interfaces;

namespace Mathematio.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly MathematioContext _context;

        public Repository(MathematioContext context)
        {
            _context = context;
        }

        public T Add(T model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model;
           
        }

        public object Delete(object searchId)
        {
            _context.Remove(searchId);
            _context.SaveChanges();
            return true;
        }

        public ICollection<T> GetAll(object searchModel)
        {
            //TODO : use reflection on _context.entity
        }

        public ICollection<T> GetOne(object searchId)
        {
            throw new NotImplementedException();
        }

        public T Update(object newModel)
        {
            throw new NotImplementedException();
        }
    }
}
