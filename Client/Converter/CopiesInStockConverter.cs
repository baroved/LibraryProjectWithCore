using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Client.Converter
{
    public class CopiesInStockConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int copies = (int)value;
            if (copies > 0)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
