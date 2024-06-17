using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency;
using System;
using System.Linq;

namespace TestProject1
{
    [TestClass]
    public class CurrencyTests
    {
        [TestMethod]
        public void ValidateNoteAndCoinDenominations()
        {
            CurrencyDenominations denominations = new CurrencyDenominations(14.5);
            int[] noteDenominations = denominations.noteDenominations;
            Assert.AreEqual(2, noteDenominations[5]);
            Assert.AreEqual(1, noteDenominations[3]);
            int[] coinDenominations = denominations.coinsDenominations;
            Assert.AreEqual(1, coinDenominations[0]);
        }

        [TestMethod]
        public void ValidateOnlyNoteDenominations()
        {
            CurrencyDenominations denominations = new CurrencyDenominations(25);
            int[] noteDenominations = denominations.noteDenominations;
            Assert.AreEqual(1, noteDenominations[2]);
            Assert.AreEqual(1, noteDenominations[4]);
        }

        [TestMethod]
        public void ValidateOnlyCoinDenominations()
        {
            CurrencyDenominations denominations = new CurrencyDenominations(0.5);
            int[] coinDenominations = denominations.coinsDenominations;
            Assert.AreEqual(1, coinDenominations[0]);
        }

        [TestMethod]
        public void ValidateZeroAmount()
        {
            CurrencyDenominations denominations = new CurrencyDenominations(0);
            int[] noteDenominations = denominations.noteDenominations;
            int[] coinDenominations = denominations.coinsDenominations;
            Assert.AreEqual(noteDenominations.All(e => e == 0), true);
            Assert.AreEqual(coinDenominations.All(e => e == 0), true);
        }
    }
}