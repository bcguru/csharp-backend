using System;
using Backend.Services;

namespace Backend.Model
{
    internal class FlatTax : ITaxMethod
    {
        public float Apply(float grossSalary) {

            // Initialize net salary to gross salary
            float netSalary = grossSalary;

            // Calculate income tax (10%) and social contributions (15%) if gross salary is over 1000 IDR
            if (grossSalary > 1000)
            {
                // Calculate taxable amount (it can't be higher than 3000 for social contributions)
                float taxableAmount = Math.Min(grossSalary, 3000);

                // Calculate income tax
                float incomeTax = (grossSalary - 1000) * 0.10f;

                // Calculate social contribution
                float socialContribution = (taxableAmount - 1000) * 0.15f;

                // Subtract taxes from net salary
                netSalary = grossSalary - incomeTax - socialContribution;
            }
            return netSalary;
        }
    }
}
