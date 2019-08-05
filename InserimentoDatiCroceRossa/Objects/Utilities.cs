using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
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
    public class WaitCursor : IDisposable
    {
        private Cursor m_oldCursor = null;

        public WaitCursor()
        {
            m_oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            Cursor.Current = m_oldCursor;
        }
    }
}
