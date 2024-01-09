using System.Drawing;
using System.IO;

namespace Common
{
    public class ImageHelper
    {
        public static Image FileToBitmapImage(string path, bool freeFile = true)
        {
            Image tmp;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                tmp = Image.FromStream(fs, false, true);
            }
            return tmp;
        }
    }
}
