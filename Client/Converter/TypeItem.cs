using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;

namespace Client.Converter
{
    public class TypeItem : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string url = "";
            var type = (string)value;
            if (type == "Book")
                url = "https://webcomicms.net/sites/default/files/clipart/129693/book-pictures-129693-1410833.jpg";
            else
            {
                if (type == "Journal")
                    url = "https://upload.wikimedia.org/wikipedia/commons/1/14/Journal_Le_Quartier_latin_Vol1_No1.jpg";
            }

            return url;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
