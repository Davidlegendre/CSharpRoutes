using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpRoutes.lib.MRoutes
{

    /// <summary>
    /// Objeto Get, Contiene: Ruta (string), Accion (Func<out object>), AccionFull (Func<in object, out object>) 
    /// y Middleware (Func<in string, out bool>).
    /// </summary>
    public partial class Get
    {

        string _ruta = "";
        Func<object> _Accion = null;
        Func<object, object> _Middleware = null;
        string[] _campos = new string[1];
        Func<object, object> _AccionConFuncion = null;

        /// <summary>
        /// La ruta a donde se navegara
        /// </summary>
        public string ruta { get => _ruta; set => _ruta = value; }

        /// <summary>
        /// Accion que se ejecutara si no se va a enviar json
        /// </summary>
        public Func<object> Accion { get => _Accion; set => _Accion = value; }

        /// <summary>
        /// Accion que se ejecutara cuando se quiera enviar jsons u otro objeto
        /// </summary>
        public Func<object, object> AccionFull { get => _AccionConFuncion; set => _AccionConFuncion = value; }

        /// <summary>
        /// El Middleware que evalua segun lo que usted desee al json
        /// obtiene un json o un objeto y devuelve un objeto
        /// </summary>
        public Func<object, object> Middleware { get => _Middleware; set => _Middleware = value; }

    }
}
