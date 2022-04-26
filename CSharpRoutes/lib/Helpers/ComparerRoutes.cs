using CSharpRoutes.lib.MRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpRoutes.lib.Gestiones;

namespace CSharpRoutes.lib.Helpers
{
    /// <summary>
    /// Hace casi lo mismo que IsRouteExits() con la diferencia de que genera excepciones si hay errores
    /// </summary>
    internal class ComparerRoutes
    {
        /// <summary>
        /// Verifica si una ruta existe
        /// </summary>
        /// <param name="Mnum">
        /// Recibe un Metodos.MGet | MPost | MPut | MDel, para saber donde buscar
        /// </param>
        /// <param name="ruta">
        /// La ruta a evaluar
        /// </param>
        /// <exception cref="Exception">
        /// Provoca una excepcion si hay error
        /// </exception>
        internal ComparerRoutes(Metodos Mnum, string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta))
                throw new Exception("Algunas de sus rutas estan vacias");
            int countr = 0;
            switch (Mnum)
            {
                case Metodos.MGet:
                    countr = RGet.Count(e => e.ruta.ToLower() == ruta.ToLower());
                    if (countr != 0)
                        throw new Exception("La Ruta: " + ruta + " Ya existe");

                    break;
                case Metodos.MPost:
                    countr = RPost.Count(e => e.ruta.ToLower() == ruta.ToLower());
                    if (countr != 0)
                        throw new Exception("La Ruta: " + ruta + " Ya existe");
                    break;
                case Metodos.MPut:

                    countr = RPut.Count(e => e.ruta.ToLower() == ruta.ToLower());
                    if (countr != 0)
                        throw new Exception("La Ruta: " + ruta + " Ya existe");

                    break;
                case Metodos.MDel:
                    countr = RDelete.Count(e => e.ruta.ToLower() == ruta.ToLower());
                    if (countr != 0)
                        throw new Exception("La Ruta: " + ruta + " Ya existe");
                    break;
            }


        }

        /// <summary>
        /// Verifica la integridad de la ruta
        /// </summary>
        /// <param name="ruta">
        /// ruta tipo objeto Get
        /// </param>
        /// <exception cref="Exception">
        /// Excepcion cuando hay errrores
        /// </exception>
        internal ComparerRoutes(Get ruta)
        {
            if (ruta.Accion == null && ruta.AccionFull == null)
                throw new Exception("Añada una Accion a la ruta " + ruta.ruta);
            else if (ruta.Accion != null && ruta.AccionFull != null)
                throw new Exception("Elija Una Sola Accion, ruta: " + ruta.ruta);
            else if (ruta.Middleware == null && ruta.AccionFull != null)
                throw new Exception("Añada un Middleware a la ruta " + ruta.ruta);

        }

        /// <summary>
        /// Verifica la integridad de la ruta
        /// </summary>
        /// <param name="ruta">
        /// ruta tipo objeto Post
        /// </param>
        /// <exception cref="Exception">
        /// Excepcion cuando hay errrores
        /// </exception>
        internal ComparerRoutes(Post ruta)
        {
            if (ruta.Accion == null)
                throw new Exception("Añada una Accion a la ruta " + ruta.ruta);
            else if (ruta.Middleware == null && ruta.Accion != null)
                throw new Exception("Añada un Middleware a la ruta " + ruta.ruta);
        }

        /// <summary>
        /// Verifica la integridad de la ruta
        /// </summary>
        /// <param name="ruta">
        /// ruta tipo objeto Put
        /// </param>
        /// <exception cref="Exception">
        /// Excepcion cuando hay errrores
        /// </exception>
        internal ComparerRoutes(Put ruta)
        {
            if (ruta.Accion == null)
                throw new Exception("Añada una Accion a la ruta " + ruta.ruta);
            else if (ruta.Middleware == null && ruta.Accion != null)
                throw new Exception("Añada un Middleware a la ruta " + ruta.ruta);
        }

        /// <summary>
        /// Verifica la integridad de la ruta
        /// </summary>
        /// <param name="ruta">
        /// ruta tipo objeto Delete
        /// </param>
        /// <exception cref="Exception">
        /// Excepcion cuando hay errrores
        /// </exception>
        internal ComparerRoutes(Delete ruta)
        {
            if (ruta.Accion == null)
                throw new Exception("Añada una Accion a la ruta " + ruta.ruta);
            else if (ruta.Middleware == null && ruta.Accion != null)
                throw new Exception("Añada un Middleware a la ruta " + ruta.ruta);
        }
        List<Get> RGet = RGestion.Get();
        List<Post> RPost = RGestion.Post();
        List<Put> RPut = RGestion.Put();
        List<Delete> RDelete = RGestion.Delete();

    }
}
