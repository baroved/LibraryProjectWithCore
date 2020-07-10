using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientLib.Service
{
    public class FilterSearch : IFilterSearch
    {
        #region Methods
        //get items by discount
        public IEnumerable<AbstractItem> GetItemsByDiscount(IEnumerable<AbstractItem> items)
        {
            return items.Where(item => item.Discount > 0).ToList();
        }

        //get items by name
        public IEnumerable<AbstractItem> GetItemsByName(IEnumerable<AbstractItem> items, string name)
        {
            return items.Where(item => item.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        //get items by type
        public IEnumerable<AbstractItem> GetItemsByType(IEnumerable<AbstractItem> items, string type)
        {
            return items.Where(item => item.Type.ToLower() == type.ToLower()).ToList();
        }
        #endregion
    }
}
