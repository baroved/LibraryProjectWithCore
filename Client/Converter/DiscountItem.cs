using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Client.Converter
{
    class DiscountItem: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int discount = (int)value;
            string url="";
            if (discount>0)
                url = "https://www.naturefurniture.co.il/wp-content/uploads/2017/12/sale.jpg";
            return url;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
