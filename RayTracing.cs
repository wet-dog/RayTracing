using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using Encoder = System.Drawing.Imaging.Encoder;

namespace RayTracing
{
    class RayTracing
    {
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                if (codec.MimeType == mimeType)
                    return codec;

            return null;
        }


        public static Ray GenerateRay(int width, int height, int x, int y, Vector3 e, Vector3 dir)
        {
            //float l = 0.0f;
            //float r = width;
            //float b = 0.0f;
            //float t = height;

            float l = -250.0f;
            float r = 250.0f;
            float b = -250.0f;
            float t = 250.0f;


            //float l = -0.5f;
            //float r = 0.5f;
            //float b = -0.5f;
            //float t = 0.5f;

            float u = l + (r - l) * (x + 0.5f) / width;
            float v = b + (t - b) * (y + 0.5f) / height;

            float dist = 25.0f;

            Vector3 up = Vector3.UnitZ;

            // -w = view direction
            Vector3 W = Vector3.Normalize(dir);
            Vector3 U = Vector3.Normalize(Vector3.Cross(up, W));
            Vector3 V = Vector3.Cross(W, U);

            //Console.WriteLine(W + " a " + U + " " + V);
            //Console.WriteLine(u + "   :    " + v);

            Vector3 d = -dist*W + u*U + v*V;
            d = Vector3.Normalize(d);
            //Console.WriteLine(d);

            Ray ray = new Ray(e, d);
            return ray;        
        }

        public void GetHit()
        {

        }

        public static void Main(string[] args)
        {
            // Vector3 a = new Vector3(1, 1, 1);
            // Vector3 b = new Vector3(2, 2, 2);
            // Vector3 result = a * b;

            // Ray ray = new Ray(new Vector3(1, 1, 1), new Vector3(-1, -1, -1));
            
            Color blue = Color.FromArgb(0, 0, 255);
            Color light_grey = Color.FromArgb(211, 211, 211);
            Material mat = new Material(blue, blue, light_grey, 10);
            Sphere sphere = new Sphere(new Vector3(0, 0, 0), 1.7f, mat);

            HitRecord rec = new HitRecord();

            // sphere.Hit(ray, 0, 1, rec);

            // Console.WriteLine(result.ToString());

            Color bgColor = Color.FromArgb(128, 128, 128);
            int width = 500;
            int height= 500;

            Bitmap bmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    // Compute viewing ray.
                    Ray r = GenerateRay(width, height, x, y, new Vector3(1, 1, 1), new Vector3(1.5f, 1.5f, 1.5f));
                    // Console.WriteLine(r.pos.ToString() + " " +  r.dir.ToString());

                    // If ray hits an object.
                    bool res = sphere.Hit(r, 0, 1, rec);
                    // Console.WriteLine(res);
                    if (res)
                    {
                        // Compute n.


                        // Evaluate shading model and set pixel to that colour.
                        bmp.SetPixel(x, y, rec.mat.k_d);

                    } 
                    else
                    {
                        bmp.SetPixel(x, y, bgColor);
                    }
                }
            }

            // Output image.
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            // Get an ImageCodecInfo object that represents the JPEG codec.
            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            // Create an Encoder object based on the GUID

            // for the Quality parameter category.
            myEncoder = Encoder.Quality;

            // Create an EncoderParameters object.

            // An EncoderParameters object has an array of EncoderParameter

            // objects. In this case, there is only one

            // EncoderParameter object in the array.
            myEncoderParameters = new EncoderParameters(1);

            // Save the bitmap as a JPEG file with quality level 25.
            myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp.Save("result.jpg", myImageCodecInfo, myEncoderParameters);

        }

    }

}
