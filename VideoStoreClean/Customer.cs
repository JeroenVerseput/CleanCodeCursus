using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStoreClean
{
    public class Customer
    {
        private readonly string _name;
        private List<Rental> _rentals = new List<Rental>(); // preserves order

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }
    }
}
