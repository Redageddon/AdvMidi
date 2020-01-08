using System.IO;
using System.Windows.Media.Imaging;

namespace AdvMidi.Modes
{
    public class GifReader
    {
        public static void GifEntrance()
        {
            Stream imageStreamSource = new FileStream("tulipfarm.gif", FileMode.Open, FileAccess.Read, FileShare.Read);
            GifBitmapDecoder decoder = new GifBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
        }
    }
}