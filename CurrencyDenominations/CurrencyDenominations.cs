using System;

namespace Currency
{
    public enum CurrencyType
    {
        Dollar = '$',
        Pound = '£'
    }



    interface ICurrency
    {
        int[] GetSupportedNotes(); // returns supported notes denominations
        int[] GetSupportedCoins(); // returns supported coins denominations

        string GetNoteType(); //returns symbol for note denominations

        string GetCoinType(); //returns symbol for coin denominations

    }

    //implementing ICurrency interface for US  currency.
    public class Dollar : ICurrency
    {
        int[] notes = new int[] { 100, 50, 20, 10, 5, 2, 1 };
        int[] coins = new int[] { 50, 25, 10, 5, 1 };

        string noteType = "$";
        string coinType = "¢";

        public int[] GetSupportedCoins()
        {
            return coins;
        }

        public int[] GetSupportedNotes()
        {
            return notes;
        }

        public string GetNoteType()
        {
            return noteType;
        }

        public string GetCoinType()
        {
            return coinType;
        }

    }

    //Implementing ICurrency interface for UK currency
    public class Pound : ICurrency
    {
        int[] notes = new int[] { 100, 50, 20, 10, 5, 2, 1 };
        int[] coins = new int[] { 50, 20, 10, 5, 2, 1 };

        string noteType = "£";
        string coinType = "p";

        public int[] GetSupportedCoins()
        {
            return coins;
        }

        public int[] GetSupportedNotes()
        {
            return notes;
        }

        public string GetNoteType()
        {
            return noteType;
        }

        public string GetCoinType()
        {
            return coinType;
        }
    }

    public class CurrencyDenominations
    {
        double amount;
        private int[] currencyNotes;
        private int[] currencyCoins;
        public int[] noteDenominations;
        public int[] coinsDenominations;
        CurrencyType currencyType;
        ICurrency currency;

        private ICurrency GetCurrency()
        {
            switch (currencyType)
            {
                case CurrencyType.Dollar:
                    return new Dollar();
                case CurrencyType.Pound:
                    return new Pound();
                default:
                    return new Pound();

            }
        }

        public void initializeSupportedCoinsAndNotes()
        {
            ICurrency currency = GetCurrency();
            currencyNotes = currency.GetSupportedNotes();
            currencyCoins = currency.GetSupportedCoins();
        }

        public CurrencyDenominations(double amount, CurrencyType currencyType = CurrencyType.Pound)
        {
            this.amount = amount;
            this.currencyType = currencyType;
            this.currency = GetCurrency();
            this.initializeSupportedCoinsAndNotes();
            noteDenominations = GetDenominations(currencyNotes, (int)amount);
            coinsDenominations = GetDenominations(currencyCoins, (amount - Math.Truncate(amount)) * 100);
        }


        public int[] GetDenominations(int[] supportedDenominations, double input_amount)
        {
            int amount = (int)Math.Round(input_amount);

            int[] counter = new int[supportedDenominations.Length];


            for (int i = 0; i < supportedDenominations.Length; i++)
            {
                if (amount >= supportedDenominations[i])
                {
                    counter[i] = amount / supportedDenominations[i];
                    amount = amount % supportedDenominations[i];
                }
                if (amount == 0)
                {
                    break;
                }
            }

            return counter;

        }

        public void PrintDenominations()
        {
            if (amount == 0.0)
            {
                Console.WriteLine("No amount to be returned as amount paid equals product price.");
                return;
            }

            for (int i = 0; i < currencyNotes.Length; i++)
            {
                if (noteDenominations[i] != 0)
                {
                    Console.WriteLine($"{noteDenominations[i]} x {this.currency.GetNoteType()}{currencyNotes[i]}");
                }
            }

            for (int i = 0; i < currencyCoins.Length; i++)
            {
                if (coinsDenominations[i] != 0)
                {
                    Console.WriteLine($"{coinsDenominations[i]} x {currencyCoins[i]}{this.currency.GetCoinType()}");
                }
            }
        }
    }
}
