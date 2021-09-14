using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RayTracing
{
    class Ray
    {

        public Vector3 pos;
        public Vector3 dir;

        public Ray(Vector3 e, Vector3 d)
        {
            pos = e;
            dir = d;
        }

    }
}
