namespace VideoStore
{
    internal static class CustomerSummaryHelper
    {
        internal static string GetCustomerSummary(Customer customer)
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;

            string result = "Rental Record for " + customer.GetName() + "\n";

            foreach (var rental in customer.GetRentals())
            {
                double amountOfRental = rental.CalculatePrice();
                totalAmount += amountOfRental;
                frequentRenterPoints += rental.CalculatePoints();

                result += "\t" + rental.GetMovie().GetTitle() + "\t"
                          + amountOfRental + "\n";
            }

            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints
                                    + " frequent renter points";
            return result;
        }
    }
}
