using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Client.Converter
{
    public class VisibilityColumPromotions:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var item = value;
            if (item == null)
                return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
