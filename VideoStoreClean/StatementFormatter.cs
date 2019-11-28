using System.Collections.Generic;
using System.Linq;

namespace VideoStoreClean
{
    public class StatementFormatter
    {
	    public string FormatStatement(string customerName, List<Rental> rentals)
        {
            return FormatHeader(customerName) +
                   FormatBody(rentals) +
                   FormatFooter(rentals);
        }

        private string FormatBody(IEnumerable<Rental> rentals)
        {
            return rentals.Select(FormatBodyLine).Aggregate((a,c) => $"{a}{c}");
        }

        private string FormatFooter(List<Rental> rentals)
        {
            return "Amount owed is " + CalculateTotalPrice(rentals) + "\n" +
                   "You earned " + CalculateTotalRenterPoints(rentals) + " frequent renter points";
        }

        private double CalculateTotalPrice(IEnumerable<Rental> rentals)
        {
            return rentals.Sum(r => r.CalculatePrice());
        }

        private int CalculateTotalRenterPoints(IEnumerable<Rental> rentals)
        {
            return rentals.Sum(r => r.CalculateRenterPoints());
        }

        private string FormatBodyLine(Rental rental)
        {
            return "\t" + rental.GetMovie().GetTitle() + "\t" + rental.CalculatePrice() + "\n";
        }

        private string FormatHeader(string customerName)
        {
            return "Rental Record for " + customerName + "\n";
        }

    }

}
