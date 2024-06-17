using System;

namespace Currency
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyType currencyType;
            Console.WriteLine("Enter product price:");
            double productPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter amount customer paid:");
            double amountPaid = Convert.ToDouble(Console.ReadLine());

            double balanceAmt = amountPaid - productPrice;

            if (balanceAmt >= 0)
            {
                CurrencyDenominations denominations = new CurrencyDenominations(balanceAmt);

                denominations.PrintDenominations();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Insufficient amount");
                Console.ReadKey();
            }

        }
    }
}
