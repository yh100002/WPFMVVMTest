using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight2.Model
{
    public class Repository : IRepository
    {
        protected readonly CustomerContext _context;

        public CustomerContext Context
        {
            get { return _context as CustomerContext; }
        }

 /*      
        public Repository(CustomerContext context)
        {
            _context = context;
        }
        */
        public Repository()
        {
            _context = new CustomerContext();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        
        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer SingleOrDefault(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetAll()
        {
            ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();
            foreach (var item in _context.Customers)
            {
                Customers.Add(item);
            }
            return Customers;
        }

        public int CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

    }
}
