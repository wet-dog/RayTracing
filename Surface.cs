using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    abstract class Surface
    {
        public abstract bool Hit(Ray ray, float t0, float t1, HitRecord rec);
        // public abstract Box BoundingBox();
            
    }

}
