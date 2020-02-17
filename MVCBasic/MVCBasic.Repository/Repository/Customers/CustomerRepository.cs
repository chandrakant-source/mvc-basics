using System.Collections.Generic;
using System.Linq;
using MVCBasic.Repository.Domain.Cutomers;

namespace MVCBasic.Repository.Repository.Customers
{
    public class CustomerRepository
    {
        #region ctor

        private static CustomerRepository instance;
        private List<Customer> Table { get; set; }
        private CustomerRepository()
        {
            Table = new List<Customer>()
            {
                new Customer { Id = 1, FirstName = "Rahul", LastName ="Jadhav", Address ="Mumbai",State="Maharashtra",EmailAddress="rahul.jadhav@yopmail.com",Phone = "123456789", ZipCode = "400089"},
                new Customer { Id = 2, FirstName = "Rakesh", LastName ="Pandit", Address ="Mumbai",State="Maharashtra",EmailAddress="rakesh.pandit@yopmail.com",Phone = "123456789", ZipCode = "400053"},
                new Customer { Id = 3, FirstName = "Kedar", LastName ="Mane", Address ="Mumbai",State="Maharashtra",EmailAddress="kedar.mane@yopmail.com",Phone = "123456789", ZipCode = "400085"},
                new Customer { Id = 4, FirstName = "Akshay", LastName ="Mane", Address ="Navi-Mumbai",State="Maharashtra",EmailAddress="akshay.mane@yopmail.com",Phone = "123456789", ZipCode = "400706"},
                new Customer { Id = 5, FirstName = "Ramesh", LastName ="Patel", Address ="Mumbai",State="Maharashtra",EmailAddress="ramesh.patel@yopmail.com",Phone = "123456789", ZipCode = "400005"},
            };
        }

        #endregion

        #region Instance
        public static CustomerRepository Data
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerRepository();
                }
                return instance;
            }
        }
        #endregion

        #region Methods
        public List<Customer> GetAll()
        {
            return Table.OrderBy(x => x.Id).ToList();
        }


        public void Update(Customer entity)
        {
            var data = this.Table.FirstOrDefault(x => x.Id == entity.Id);
            data.LastName = entity.LastName;
            data.FirstName = entity.FirstName;
            data.Phone = entity.Phone;
            data.Address = entity.Address;
            data.EmailAddress = entity.EmailAddress;
            data.State = entity.State;
            data.ZipCode = entity.ZipCode;
        }


        public void Add(Customer model)
        {
            this.Table.Add(model);
        }

        #endregion
    }
}
