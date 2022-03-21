using System.Collections.Generic;

namespace VideoStore
{
    internal class Customer
    {
        private string name;
        private List<Rental> rentals = new List<Rental>();

        internal Customer(string name)
        {
            this.name = name;
        }

        internal string GetName()
        {
            return name;
        }

        internal List<Rental> GetRentals()
        {
            return rentals;
        }

        internal void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }
    }
}
