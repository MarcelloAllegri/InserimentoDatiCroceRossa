using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InserimentoDatiCroceRossa.Converters
{   
        public class BoolToImageConverter : IValueConverter
        {
            private string path = "";
            public BoolToImageConverter()
            {
            path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName.ToString() + "\\Images\\Menu\\";
            }

            public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if ((value.ToString() == "True" || value.ToString() == "1") ? true : false)
                    return path + "Enabled.png";
                else
                    return path + "NotEnable.png";
            }

            public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
    
}
