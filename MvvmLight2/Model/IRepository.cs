using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight2.Model
{
    public interface IRepository
    {
        Customer Get(int id);
        
        IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate);

        Customer SingleOrDefault(Expression<Func<Customer, bool>> predicate);

        void Add(Customer entity);
        void AddRange(IEnumerable<Customer> entities);

        void Remove(Customer entity);
        void RemoveRange(IEnumerable<Customer> entities);

        ObservableCollection<Customer> GetAll();

        int CreateCustomer(Customer customer);
    }
}
