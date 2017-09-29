using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Internals {
    public static class Surfaces {
        public static Surface FindSurface(string name) {
            Type surfaceAttribute = Type.GetType("RayTracer.Internals.SurfaceAttribute");
            Type surfaceType = Type.GetType("RayTracer.Internals.Surfaces");
            foreach (var mi in surfaceType.GetFields())
            {
                foreach (var a in mi.CustomAttributes)
                {
                    if (a.AttributeType == surfaceAttribute)
                    {
                        // we have a member of the class that is marked as a Surface
                        if (mi.Name == name)
                        {
                            return mi.GetValue(null) as Surface;
                        }
                    }
                }
            }
            return null;
        }


        // Only works with X-Z plane.
        [Surface]
        public static readonly Surface CheckerBoard =
            new Surface() {
                Diffuse = pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? Color.Make(1, 1, 1)
                                    : Color.Make(0, 0, 0),
                Specular = pos => Color.Make(1, 1, 1),
                Reflect = pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? .1
                                    : .7,
                Roughness = 150
            };

        [Surface]
        public static readonly Surface Shiny =
            new Surface() {
                Diffuse = pos => Color.Make(1, 1, 1),
                Specular = pos => Color.Make(.5, .5, .5),
                Reflect = pos => .6,
                Roughness = 50
            };

        [Surface]
        public static readonly Surface NonShiny =
            new Surface() {
                Diffuse = pos => Color.Make(1, 1, 1),
                Specular = pos => Color.Make(.5, .5, .5),
                Reflect = pos => 0,
                Roughness = 50
            };
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class SurfaceAttribute : Attribute
    {
        //
    }
}
