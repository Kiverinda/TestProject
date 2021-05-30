using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TestProject.Model.Repo.Interfaces
{
    public interface IRepoBase<T>
    {
        Task<T> GetItem(Guid id);
        ObservableCollection<T> GetItems();
        Task Add(T item);
        Task Update(T item);

        Task Delete(Guid id);
    }
}