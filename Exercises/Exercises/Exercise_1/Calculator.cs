using System.Collections.Generic;

namespace Exercises.Exercises.Exercise_1
{
	public class Calculator
	{
        public decimal CalculateSelfEmploymentIncomeForMortgage(List<SelfEmployment> selfEmployments)
        {
            var totalIncomeFromSelfEmployments = 0m;

            foreach (var selfEmployment in selfEmployments)
            {
                // Wanneer alle drie de jaren worden ingevuld kunnen we voor 100% berekenen
                if (selfEmployment.NetProfitThirdLastYear > 0)
                {
                    var averageIncome = (selfEmployment.NetProfitThirdLastYear +
                                         selfEmployment.NetProfitSecondLastYear +
                                         selfEmployment.NetProfitLastYear) / 3m;

                    var incomeUsedForCalculation = selfEmployment.NetProfitLastYear < averageIncome
                        ? selfEmployment.NetProfitLastYear
                        : averageIncome;

                    totalIncomeFromSelfEmployments += incomeUsedForCalculation * 1.00m;
                }
                // Wanneer we alleen voor de afgelopen twee jaar ontvangen mogen we deze alleen voor maar 90% berekenen
                else if (selfEmployment.NetProfitSecondLastYear > 0)
                {
                    var averageIncome = (selfEmployment.NetProfitSecondLastYear + selfEmployment.NetProfitLastYear) / 2m;

                    var incomeUsedForCalculation = selfEmployment.ExpectedNetProfitCurrentYear < averageIncome
                        ? selfEmployment.ExpectedNetProfitCurrentYear
                        : averageIncome;

                    totalIncomeFromSelfEmployments += incomeUsedForCalculation * 0.90m;
                }
                // Wanneer we allen voor afgelopen jaar hebben kunnen we maar voor 75% berekenen
                else
                {
                    var averageIncome = selfEmployment.NetProfitLastYear;

                    var incomeUsedForCalculation = selfEmployment.ExpectedNetProfitCurrentYear < averageIncome
                        ? selfEmployment.ExpectedNetProfitCurrentYear
                        : averageIncome;

                    totalIncomeFromSelfEmployments += incomeUsedForCalculation * 0.75m;
                }
            }

            return totalIncomeFromSelfEmployments;
        }
    }

    /// <summary>
	/// Inkomen als ondernemer.
	/// </summary>
	public class SelfEmployment
    {
        /// <summary>
		/// Verwachte netto winst van huidig jaar.
		/// </summary>
        public decimal ExpectedNetProfitCurrentYear { get; set; }

        /// <summary>
        /// Netto winst van afgelopen jaar.
        /// </summary>
        public decimal NetProfitLastYear { get; set; }

        /// <summary>
        /// Netto winst van 2 jaar terug.
        /// </summary>
        public decimal NetProfitSecondLastYear { get; set; }

        /// <summary>
        /// Netto winst van 3 jaar terug.
        /// </summary>
        public decimal NetProfitThirdLastYear { get; set; }
    }
}
