using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario6_Lp
{
    public static class GalaxyClass
    {
       
        public static void ShowGalaxies()
        {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Debug.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
        }

        //El siguiente ejemplo demuestra un atributo get que es un iterador.
        //En el ejemplo, cada yield return retorna una instancia de una clase definida por el usuario.
        public class Galaxies
        {

            public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy
            {
                get
                {
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                }
            }
        }
        public class Galaxy
        {
            public String Name { get; set; }
            public int MegaLightYears { get; set; }
        }

    }
}
