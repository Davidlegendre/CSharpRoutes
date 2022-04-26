using CSharpRoutes.lib.MRoutes;
using CSharpRoutes.lib.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpRoutes.lib.Gestiones
{
    public static class RGestion
    {
        /// <summary>
        /// Verifica si una ruta existe
        /// </summary>
        /// <param name="metodo">
        /// Recibe un Metodos.MGet | MPost | MPut | MDel, para saber donde buscar
        /// </param>
        /// <param name="ruta">
        /// la ruta a evaluar
        /// </param>
        /// <returns>
        /// retorna un bool, true si existe y falso si no
        /// </returns>
        public static bool IsRouteExits(Metodos metodo, string ruta)
        {
            switch (metodo)
            {
                case Metodos.MGet:
                    return Get().Count(e => e.ruta.ToLower() == ruta.ToLower()) != 0;
                case Metodos.MPost:
                    return Post().Count(e => e.ruta.ToLower() == ruta.ToLower()) != 0;
                case Metodos.MPut:
                    return Put().Count(e => e.ruta.ToLower() == ruta.ToLower()) != 0;
                case Metodos.MDel:
                    return Delete().Count(e => e.ruta.ToLower() == ruta.ToLower()) != 0;
                default:
                    return false;
            }
            
        }

        /// <summary>
        /// Agrega una ruta de tipo Post a la lista
        /// </summary>
        /// <param name="postRuta">
        /// Objeto de Tipo Post
        /// </param>
        public static void Post(Post postRuta)
        {
            new ComparerRoutes(Metodos.MPost, postRuta.ruta);
            new ComparerRoutes(postRuta);
            Rutas.RPost.Add(postRuta);
        }

        /// <summary>
        /// Agrega una ruta de tipo Get a la lista
        /// </summary>
        /// <param name="getRuta">
        /// Objeto de Tipo Get
        /// </param>
        public static void Get(Get getRuta)
        {
            new ComparerRoutes(Metodos.MGet, getRuta.ruta);
            new ComparerRoutes(getRuta);
            Rutas.RGet.Add(getRuta);
        }

        /// <summary>
        /// Agrega una ruta de tipo Put a la lista
        /// </summary>
        /// <param name="putRuta">
        /// Objeto de Tipo Put
        /// </param>
        public static void Put(Put putRuta)
        {
            new ComparerRoutes(Metodos.MPut, putRuta.ruta);
            new ComparerRoutes(putRuta);
            Rutas.RPut.Add(putRuta);

        }

        /// <summary>
        /// Agrega una ruta de tipo Delete a la lista
        /// </summary>
        /// <param name="deleteRuta">
        /// Objeto de Tipo Delete
        /// </param>
        public static void Delete(Delete deleteRuta)
        {
            new ComparerRoutes(Metodos.MDel, deleteRuta.ruta);
            new ComparerRoutes(deleteRuta);
            Rutas.RDelete.Add(deleteRuta);
        }
        public static void DirectRoute(DirectRoute directRoute)
        {
            new ComparerRoutes(Metodos.MDestinos, directRoute.ruta);
            new ComparerRoutes(directRoute);
            Rutas.RDirectRoutes.Add(directRoute);
        }

        /// <summary>
        /// Obtiene la lista completa de las rutas Post
        /// </summary>
        internal static List<Post> Post()
        {
            return Rutas.RPost;
        }

        /// <summary>
        /// Obtiene la lista completa de las rutas Get
        /// </summary>
        internal static List<Get> Get()
        {
            return Rutas.RGet;
        }


        /// <summary>
        /// Obtiene la lista completa de las rutas Put
        /// </summary>
        internal static List<Put> Put()
        {
            return Rutas.RPut;
        }

        /// <summary>
        /// Obtiene la lista completa de las rutas Delete
        /// </summary>
        internal static List<Delete> Delete()
        {
            return Rutas.RDelete;
        }

        internal static List<DirectRoute> DirectRoutes()
        {
            return Rutas.RDirectRoutes;
        }

        public static object GetData(object json)
        {
            try
            {
                if (json != null)
                {
                    JObject.Parse((string)json);
                    return JObject.Parse((string)json).GetValue("Data").ToString();
                }
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }

        }
        public static object GetMensaje(object json)
        {
            try
            {
                if (json != null)
                {
                    JObject.Parse((string)json);
                    return JObject.Parse((string)json).GetValue("Mensaje").ToString();
                }
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static object GetResultado(object json)
        {
            try
            {
                if (json != null)
                {
                    JObject.Parse((string)json);
                    return JObject.Parse((string)json).GetValue("Resultado").ToString();
                }
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
