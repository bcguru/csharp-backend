using log4net;
using System;

namespace Backend.Services
{
    internal class SalaryService : ISalaryService
    {   
        private readonly ITaxMethod[] _taxes;
        private static readonly ILog _log = LogManager.GetLogger(typeof(SalaryService));
        public SalaryService(ITaxMethod[] taxes) {
            _taxes = taxes;
        }
        public void Calculate() {
            Console.WriteLine("Calculate Net Salary");
            try
            {
                // Read gross salary from input
                Console.WriteLine("Enter Gross Salary: ");
                float grossSalary;

                if (!float.TryParse(Console.ReadLine(), out grossSalary))
                {
                    throw new FormatException();
                }
                if (grossSalary < 0)
                {
                    throw new ArgumentException("Gross salary must be a non-negative number.");
                }

                float netSalary = grossSalary;

                foreach (var tax in _taxes)
                {
                    netSalary = tax.Apply(netSalary);
                }

                // Output the result
                Console.WriteLine($"Net Salary: {netSalary:F2} IDR");
            }
            catch (FormatException ex)
            {
                _log.Error("Error: Invalid input format.", ex);
                Console.WriteLine("Please enter valid Gross Salary.");
            }
            catch (ArgumentException ex)
            {
                _log.Error("Error: Invalid argument.", ex);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error("An unexpected error occurred", ex);
                Console.WriteLine("An unexpected error occurred. Please try again.");
            }
        }
    }
}
