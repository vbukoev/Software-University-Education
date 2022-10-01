using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string removedCustomer { get; set; }
        public Customer(string name, string address, string removedCustomer)
        {
            this.Name = name;
            this.Address = address;
            this.removedCustomer = removedCustomer;
        }
    }
}
