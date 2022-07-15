namespace Mathematio.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public ICollection<T> GetAll(object searchModel);

        public ICollection<T> GetOne(object searchId);

        public T Add(T model);

        public T Update(object newModel);

        public object Delete(object searchId);


    }
}
