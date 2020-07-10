using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLib.Api
{
    public interface IFilterSearch
    {
        #region Methods
        IEnumerable<AbstractItem> GetItemsByName(IEnumerable<AbstractItem> items,string name);
        IEnumerable<AbstractItem> GetItemsByType(IEnumerable<AbstractItem> items, string type);
        IEnumerable<AbstractItem> GetItemsByDiscount(IEnumerable<AbstractItem> items);
        #endregion
    }
}
