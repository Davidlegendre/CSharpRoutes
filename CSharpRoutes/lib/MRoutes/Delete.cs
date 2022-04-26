using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpRoutes.lib.MRoutes
{
    /// <summary>
    /// Objeto Delete, Contiene: Ruta (string), Accion (Func<in object, out object>) y Middleware (Func<in object, out bool>)
    /// </summary>
    public partial class Delete
    {

        string _ruta = "";
        Func<object, object> _AccionConFuncion = null;

        Func<object, object> _Middleware = null;

        /// <summary>
        /// La ruta a donde se navegara
        /// </summary>
        public string ruta { get => _ruta; set => _ruta = value; }

        /// <summary>
        /// Accion que se ejecutara una vez pasado el Middleware
        /// obtiene un json o un objeto y devuelve un objeto
        /// </summary>
        public Func<object, object> Accion { get => _AccionConFuncion; set => _AccionConFuncion = value; }

        /// <summary>
        /// El Middleware que evalua segun lo que usted desee al json
        /// obtiene un json o un objeto y devuelve un objeto
        /// </summary>
        public Func<object, object> Middleware { get => _Middleware; set => _Middleware = value; }


    }
}
