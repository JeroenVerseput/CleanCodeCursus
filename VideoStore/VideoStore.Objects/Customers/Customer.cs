using System;
using System.Collections.Generic;

namespace VideoStore.Objects.Customers
{
    public class Customer
    {
        private readonly string name;
        private readonly IList<RentalRecord> RentalRecordCollection;

        public Customer(string name)
        {
            this.name = name;
            RentalRecordCollection = new List<RentalRecord>();
        }

        public void AddRentalRecord(RentalRecord rentalRecord)
        {
            if (rentalRecord == null)
            {
                throw new ArgumentException("Rental record cannot be null.");
            }

            RentalRecordCollection.Add(rentalRecord);
        }

        public override string ToString()
        {
            decimal totalAmount = 0;
            var frequentRenterPoints = 0;
            var result = "Rental Record for " + name + "\n";

            foreach(var record in RentalRecordCollection)
            {
                totalAmount += record.GetRentalPrice();
                frequentRenterPoints += record.GetFrequentRenterPoints();
                result += record.ToString();
            }

            result += "Amount owed is " + (int) totalAmount + "\n";
            result += "You earned " + frequentRenterPoints
                                    + " frequent renter points";

            return result;
        }
    }
}
