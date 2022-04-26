using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CSharpRoutes.lib.MRoutes;

namespace CSharpRoutes.lib
{
    internal static class Rutas
    {
        static List<Post> _Insert = new List<Post>();
        static List<Put> _Update = new List<Put>();
        static List<Delete> _Delete = new List<Delete>();
        static List<Get> _Select = new List<Get>();
        static List<DirectRoute> _DirectRoutes = new List<DirectRoute>();
        public static List<Post> RPost { get => _Insert; set => _Insert = value; }
        public static List<Put> RPut { get => _Update; set => _Update = value; }
        public static List<Get> RGet { get => _Select; set => _Select = value; }
        public static List<Delete> RDelete { get => _Delete; set => _Delete = value; }
        public static List<DirectRoute> RDirectRoutes { get => _DirectRoutes; set => _DirectRoutes = value; }
    }
}
