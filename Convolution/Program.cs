using System;
using System.IO;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Convolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var zero = CvInvoke.Imread(Path.Join("resources", "zero.jpg"), Emgu.CV.CvEnum.ImreadModes.Color).ToImage<Bgr,byte>();            
            //blur
            var blurred = new Mat();
            CvInvoke.GaussianBlur(zero, blurred, new System.Drawing.Size(9, 9), 9);
            var blurredImage = blurred.ToImage<Bgr, byte>();

            //sharpen
            var detail = (zero - blurredImage) * 2;
            var sharpened = zero + detail;

            CvInvoke.Imshow("detail", detail);
            CvInvoke.Imshow("zero", zero.Convert<Bgr, byte>());
            CvInvoke.Imshow("blurred", blurredImage.Convert<Bgr, byte>());
            CvInvoke.Imshow("Sharpened", sharpened);
            CvInvoke.WaitKey(0);
        }
    }
}
