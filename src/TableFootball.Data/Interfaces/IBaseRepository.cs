namespace TableFootball.Data.Interfaces
{
    using System.Collections.Generic;

    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        void Create(T entity);
    }
}