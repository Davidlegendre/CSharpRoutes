using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpRoutes.lib.MRoutes
{
    /// <summary>
    /// Objeto Put, Contiene: Ruta (string), Accion (Func<in object, out object>) y Middleware (Func<in object, out object>)
    /// </summary>
    public partial class Put
    {
        string _ruta = "";
        Func<object, object> _Accion = null;
        Func<object, object> _Middleware = null;

        /// <summary>
        /// La ruta a donde se navegara
        /// </summary>
        public string ruta { get => _ruta; set => _ruta = value; }

        /// <summary>
        /// Accion que se ejecutara una vez pasado el Middleware
        /// </summary>
        public Func<object, object> Accion { get => _Accion; set => _Accion = value; }

        /// <summary>
        /// El Middleware que evalua segun lo que usted desee al json
        /// obtiene un json o un objeto y devuelve un objeto
        /// </summary>
        public Func<object, object> Middleware { get => _Middleware; set => _Middleware = value; }

    }
}
