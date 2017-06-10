using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmLight2.Messages;
using MvvmLight2.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace MvvmLight2.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {        
        private readonly IRepository _repository;

        private ObservableCollection<Customer> _customers;

        private Customer _customer;

        private string _customerName;
        public RelayCommand ReadAllCommand { get; set; }
        public RelayCommand<Customer> SaveCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand<Customer> SendCustomerCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IRepository repo)
        {
            _repository = repo;

            Customers = new ObservableCollection<Customer>();

            Customer = new Customer();

            ReadAllCommand = new RelayCommand(GetAllCustomers);

            SaveCommand = new RelayCommand<Customer>(SaveCustomer);

            SearchCommand = new RelayCommand(SearchCustomer);

            SendCustomerCommand = new RelayCommand<Customer>(SendCustomerInfo);

            ReceiveCustomerInfo();

            GetAllCustomers();
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;

                RaisePropertyChanged("Customers");
            }
        }

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;

                RaisePropertyChanged("Customer");
            }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;

                RaisePropertyChanged("CustomerName");
            }
        }

        void GetAllCustomers()
        {
            this.Customers.Clear();

            foreach(var item in _repository.GetAll())
            {
                this.Customers.Add(item);
            }
        }

        void SaveCustomer(Customer customer)
        {
            Customer.Id = _repository.CreateCustomer(customer);
            if (Customer.Id != 0)
            {
                Customers.Add(Customer);
                RaisePropertyChanged("Customer");
            }
        }

        void SearchCustomer()
        {
            this.Customers.Clear();

            var searched = from c in _repository.GetAll()
                           where c.Name.StartsWith(CustomerName)
                           select c;

            foreach(var item in searched)
            {
                this.Customers.Add(item);
            }
        }

        void SendCustomerInfo(Customer customer)
        {
            if (customer != null)
            {
                Messenger.Default.Send<CustomerMsg>(new CustomerMsg()
                {
                    Customer = customer
                });
            }
        }

        void ReceiveCustomerInfo()
        {
            if (Customer != null)
            {
                Messenger.Default.Register<CustomerMsg>(this, (msg) => {
                    this.Customer = msg.Customer;
                });
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}