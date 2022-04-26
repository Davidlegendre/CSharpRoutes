using CSharpRoutes.lib.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpRoutes.lib.MRoutes
{
   public class DirectRoute
    {
        string _ruta = "";
        Destinos _Destinos = null;
        object _paquete = null;

        /// <summary>
        /// La ruta a donde se navegara
        /// </summary>
        public string ruta { get => _ruta; set => _ruta = value; }

        public void SetPaquete(object paquete)
        {
            _paquete = paquete;
        }

        public object GetPaquete()
        {
            return _paquete;
        }

        /// <summary>
        /// Obtiene los destinos a los que va dirigido los datos
        /// </summary>
        public Destinos Destinos { get => _Destinos; set => _Destinos = value; }
    }
}
