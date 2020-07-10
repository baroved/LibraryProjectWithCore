using BusinessLogic.InputValidation;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTesting
{
    public class SellTesting
    {
        #region MethodsTesting
        [Fact]
        public void Sell()
        {
            Sale newSale = new Sale()
            {
                ItemId = 1,
                CustomerId = 2,
                UserId = 1,
                Date = DateTime.Now
            };
            ValidationInputs test = new ValidationInputs();

            bool ok = test.ValidForBuying(newSale);
            Assert.True(ok);
        }

        [Fact]
        public void SellError()
        {
            Sale newSale = new Sale()
            {
                ItemId = 1,
                CustomerId = 2,
                Date = DateTime.Now
            };
            ValidationInputs test = new ValidationInputs();

            bool ok = test.ValidForBuying(newSale);
            Assert.False(ok);
        }
        #endregion
    }
}
