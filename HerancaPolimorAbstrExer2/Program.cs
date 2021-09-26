using HerancaPolimorAbstrExer2.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace HerancaPolimorAbstrExer2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char ic = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ic == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExp = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(healthExp, name, anualIncome));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberEmp = int.Parse(Console.ReadLine());
                    list.Add(new Company(numberEmp, name, anualIncome));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            double sum = 0;
            foreach (TaxPayer payer in list)
            {
                sum += payer.Tax();
                Console.WriteLine($"{payer.Name}: $ {payer.Tax().ToString("F2", CultureInfo.InvariantCulture)}");
            }

            Console.WriteLine();
            Console.Write($"TOTAL TAXES: $ {sum.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
