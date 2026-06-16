using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;                                                    


namespace SAFRANIT
{
    public class Images
    {
        public static string SaveImage(string soueceFileName)
        {
            string fileName = System.IO.Path.GetFileName(soueceFileName);
            string path = GetCurrentPath() + @"\Images\" + fileName;
            if (!File.Exists(path))
            {
                byte[] imgArray = File.ReadAllBytes(soueceFileName);
                var stream = new MemoryStream(imgArray);
                Image img = Image.FromStream(stream);
                img.Save(path);
            }
            return fileName;
        }
        public static string GetCurrentPath()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            int x = path.IndexOf(@"\bin");
            path = path.Substring(0, x);
            return path;
        }
        public static BitmapImage GetImage(string fileName)
        {
            if (fileName == "")
                return null;
            string path = GetCurrentPath() + @"\Images\" + fileName;
            if (!File.Exists(path))
            {
                byte[] imageArr = Global.proxy.GetImage(fileName);
                if (imageArr == null)
                    return null;
                var stream = new MemoryStream(imageArr);
                Image img = Image.FromStream(stream);
                img.Save(path);

            }
            return new BitmapImage(new Uri(path));
        }
        public static string UploadImage_Dlg()
        {
            string filename = null;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Images |*.jpg; *.jpeg;*.tif;*.tiff;*.bmp;*.png" + "|JPEG Files (*.jpeg)|*.jpeg" + "|PNG Files (*.png)*|.png" + "|JPG Files (*.jpg)*|.jpg" + "|GIF Files (*.gif)*|.gif";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                filename = dlg.FileName;
                filename = SaveImage(filename);
            }
            return filename;


        }
        public static async void SendImage(string image)
        {
            string path = GetCurrentPath() + @"\Images\" + image;
            byte[] imgArray = File.ReadAllBytes(path);
            await Global.proxy.SaveImgAsync(imgArray, image);
        }
    }
}
