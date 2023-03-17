using Lab.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.Logic {
    public class CustomerLogic : BaseLogic {
        
        public List<Customers> GetAll() {

            return (from Customer in _context.Customers
                    select Customer).ToList();
        }

        public Customers GetOne() {

            var customer = _context.Customers.FirstOrDefault();

            if (customer == null) throw new ArgumentNullException();

            return customer;
        }
 
        public List<Customers> RegionWA() {

            return _context.Customers.Where(c => c.Region == "WA").ToList();
        }

        public List<string> CustomersName() {

            return _context.Customers.Select(e => e.ContactName).ToList();
        }

        public List<CustomerDTO> CustomerOrder() {

            var customers = from c in _context.Customers
                            join o in _context.Orders
                            on c.CustomerID equals o.CustomerID
                            where c.Region == "WA" && o.OrderDate > new DateTime(1997,1,1)
                            select new CustomerDTO {
                                Id = c.CustomerID,
                                Name = c.ContactName,
                                Region = c.Region,
                                OrderDate = (DateTime)o.OrderDate
                            };

            return customers.ToList();
        }

        public List<Customers> RegionWaThree() {

            var customerWa = (  from c in _context.Customers
                                where c.Region == "WA"
                                select c).Take(3);
            return customerWa.ToList();
        }

        public List<CustomerOrder> CantCustomerOrder() {

            var cantCustomer = _context.Customers.GroupJoin(_context.Orders,
                                                            c => c.CustomerID,
                                                            o => o.CustomerID,
                                                            (customer, order) => new CustomerOrder {
                                                                Id = customer.CustomerID,
                                                                CantOrder = order.Count()
                                                             });

            return cantCustomer.ToList();
        }
    }
}