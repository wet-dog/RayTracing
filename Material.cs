using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayTracing
{
    class Material
    {

        public Color k_a;
        public Color k_d;
        public Color k_s;
        public float p;

        public Material(Color ambient, Color diff, Color spec, float phong)
        {
            k_a = ambient;
            k_d = diff;
            k_s = spec;
            p = phong;
        }

    }
}
