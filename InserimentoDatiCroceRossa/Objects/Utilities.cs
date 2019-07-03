using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace InserimentoDatiCroceRossa.Objects
{
    public class Images : MarkupExtension
    {
        private string path = "\\Images\\Menu\\";
        public string ImageName { get; set; }

        public Images() { }        
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return BitmapConversion.BitmapToBitmapSource((Bitmap)Bitmap.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + path + ImageName + ".png", true));             
        }

        public static class BitmapConversion
        {
            public static BitmapSource BitmapToBitmapSource(Bitmap source)
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                              source.GetHbitmap(),
                              IntPtr.Zero,
                              Int32Rect.Empty,
                              BitmapSizeOptions.FromEmptyOptions());
            }
        }
    }
}
