using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RayTracing
{
    class Sphere : Surface
    {

        private Vector3 centre;
        private float radius;
        private Material mat;

        public Sphere(Vector3 c, float r, Material m)
        {
            centre = c;
            radius = r;
            mat = m;
        }

        public override bool Hit(Ray ray, float t0, float t1, HitRecord rec)
        {

            Vector3 ec = ray.pos - centre;
            float dd = Vector3.Dot(ray.dir, ray.dir);
            float b = Vector3.Dot(ray.dir, ec);
            float ac = dd * (Vector3.Dot(ec, ec) - radius*radius);
            float disc = b*b - ac;
            //Console.WriteLine(disc);

            if (disc < 0)
            {
                return false;
            }


            float t_0 = (Vector3.Dot(-ray.dir, ec) + (float)Math.Sqrt(disc)) / dd;
            float t_1 = (Vector3.Dot(-ray.dir, ec) - (float)Math.Sqrt(disc)) / dd;
            
            if (t_0 < 0 && t_1 < 0)
            {
                return false;
            }

            if (t_0 < 0 && t_1 > 0)
            {
                rec.t = t_1;
            }
            if (t_1 < 0 && t_0 > 0)
            {
                rec.t = t_0;
            }
            else
            {
                rec.t = Math.Min(t_0, t_1);
            }
            


            // Console.WriteLine(Math.Min(t_0, t_1));
            //Console.WriteLine(t_0 + " " + t_1);

            //rec.t = Math.Min(t_0, t_1);
            rec.mat = mat;
            Vector3 p = ray.pos + rec.t * ray.dir;
            rec.n = (p - centre) / radius;

            return true;
            
        }

    }
}
