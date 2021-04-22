using System.Collections.Generic;
using System.Linq;

namespace Exercises.Exercises.Exercise_1
{
    public class Calculator
    {
        public decimal CalculateSelfEmploymentIncomeForMortgage(IEnumerable<SelfEmployment> selfEmployments)
        {
            return selfEmployments.Sum(selfEmployment =>
            {
                if (selfEmployment.NetProfitThirdLastYear > 0)
                {
                    return CalculateIncomeForTheGiveLastThreeYears(selfEmployment) * 1.00m;
                }

                if (selfEmployment.NetProfitSecondLastYear > 0)
                {
                    return CalculateIncomeForTheGiveLastTwoYears(selfEmployment) * 0.90m;
                }

                return CalculateIncomeForTheGiveLastYear(selfEmployment) * 0.75m;
            });
        }

        private static decimal CalculateIncomeForTheGiveLastYear(SelfEmployment selfEmployment)
        {
            return GetExpectedNetProfitCurrentYearIfGraterThanAverageIncome(selfEmployment.ExpectedNetProfitCurrentYear, selfEmployment.NetProfitLastYear);
        }

        private static decimal CalculateIncomeForTheGiveLastTwoYears(SelfEmployment selfEmployment)
        {
            var averageIncome = (selfEmployment.NetProfitSecondLastYear + selfEmployment.NetProfitLastYear) / 2m;

            return GetExpectedNetProfitCurrentYearIfGraterThanAverageIncome(selfEmployment.ExpectedNetProfitCurrentYear,
                averageIncome);
        }

        private static decimal GetExpectedNetProfitCurrentYearIfGraterThanAverageIncome(decimal expectedNetProfitCurrentYear, decimal averageIncome)
        {
            return expectedNetProfitCurrentYear < averageIncome
                ? expectedNetProfitCurrentYear
                : averageIncome;
        }

        private static decimal CalculateIncomeForTheGiveLastThreeYears(SelfEmployment selfEmployment)
        {
            var averageIncome = (selfEmployment.NetProfitThirdLastYear +
                                 selfEmployment.NetProfitSecondLastYear +
                                 selfEmployment.NetProfitLastYear) / 3m;

            return selfEmployment.NetProfitLastYear < averageIncome
                ? selfEmployment.NetProfitLastYear
                : averageIncome;
        }

        public class SelfEmployment
        {
            public decimal ExpectedNetProfitCurrentYear { get; set; }

            public decimal NetProfitLastYear { get; set; }

            public decimal NetProfitSecondLastYear { get; set; }

            public decimal NetProfitThirdLastYear { get; set; }
        }
    }
}