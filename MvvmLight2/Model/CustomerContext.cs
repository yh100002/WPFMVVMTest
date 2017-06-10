using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MvvmLight2.Model
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("name=CustomerContext")
        {           
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
