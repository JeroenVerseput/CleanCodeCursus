using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    public interface IFrequentRenterPointsCalculator
    {
        int CalculateFrequentRenterPoints(int daysRented);
    }

    public class DefaultFrequentRenterPointsCalculator : IFrequentRenterPointsCalculator
    {
        public int CalculateFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    public class NewReleaseFrequentRenterPointsCalculator : IFrequentRenterPointsCalculator
    {
        public int CalculateFrequentRenterPoints(int daysRented)
        {
            var amount = 1;

            if (daysRented > 1)
            {
                amount += 1;
            }

            return amount;
        }
    }
}
