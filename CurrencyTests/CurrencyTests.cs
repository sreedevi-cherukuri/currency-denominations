using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency;

namespace TestProject1
{
    [TestClass]
    public class CurrencyTests
    {
        [TestMethod]
        public void ValidateDenominations()
        {
            CurrencyDenominations denominations = new CurrencyDenominations(14.5);
            int[] noteDenominations = denominations.noteDenominations;
            Assert.AreEqual(2, noteDenominations[5]);
            Assert.AreEqual(1, noteDenominations[3]);
            int[] coinDenominations = denominations.coinsDenominations;
            Assert.AreEqual(1, coinDenominations[0]);
        }
    }
}