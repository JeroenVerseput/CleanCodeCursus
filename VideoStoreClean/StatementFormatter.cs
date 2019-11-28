using System.Collections.Generic;
using System.Linq;

namespace VideoStoreClean
{
    public class StatementFormatter
    {

        public string formatStatement(string customerName, List<Rental> rentals)
        {
            return formatHeader(customerName) +
                   formatBody(rentals) +
                   formatFooter(rentals);
        }

        private string formatBody(IEnumerable<Rental> rentals)
        {
            return rentals.Select(formatBodyLine).Aggregate((a,c) => $"{a}{c}");
        }

        private string formatFooter(List<Rental> rentals)
        {
            return "Amount owed is " + calculateTotalPrice(rentals) + "\n" +
                   "You earned " + calculateTotalRenterPoints(rentals) + " frequent renter points";
        }

        private double calculateTotalPrice(IEnumerable<Rental> rentals)
        {
            return rentals.Sum(r => r.CalculatePrice());
        }

        private int calculateTotalRenterPoints(IEnumerable<Rental> rentals)
        {
            return rentals.Sum(r => r.CalculateRenterPoints());
        }

        private string formatBodyLine(Rental rental)
        {
            return "\t" + rental.GetMovie().GetTitle() + "\t" + rental.CalculatePrice() + "\n";
        }

        private string formatHeader(string customerName)
        {
            return "Rental Record for " + customerName + "\n";
        }

    }

}
