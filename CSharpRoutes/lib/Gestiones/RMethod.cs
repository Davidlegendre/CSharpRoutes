using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpRoutes.lib.Gestiones;
using CSharpRoutes.lib.Responses;
using CSharpRoutes.lib.Helpers;
using CSharpRoutes.lib.MRoutes;

namespace CSharpRoutes.lib.Gestiones
{
    public class RMethod
    {

        /// <summary>
        /// Metodo Get, sirve para obtener datos de una ruta especifica
        /// </summary>
        /// <param name="stringruta">
        /// Recibe la ruta ya establecida
        /// </param>
        /// <param name="json">
        /// Recibe el formato Json para hacer evaluaciones
        /// </param>
        /// <returns name="Object">
        /// si hay una respuesta o todo esta correcto devolvera un objeto dependiendo de su backend, sino devolvera false
        /// </returns>
        public static object Get(string stringruta, string json = null)
        {
            if (!string.IsNullOrWhiteSpace(stringruta))
            {
                if (RGestion.IsRouteExits(Metodos.MGet, stringruta))
                {
                    if (json == null)
                    {
                        ReponseRoutesNotice response = new ReponseRoutesNotice();
                        response.Resultado = true;
                        response.Mensaje = "json nulo";
                        response.Data =  RGestion.Get().Find(e => e.ruta == stringruta).Accion.Invoke() ;
                        return JsonConvert.SerializeObject(response);
                    }
                    else
                    {

                        var mid = (ReponseRoutesNotice)RGestion.Get().Find(e => e.ruta == stringruta).Middleware.Invoke(json);
                        if (mid.Resultado == true)
                        {
                            ReponseRoutesNotice response = new ReponseRoutesNotice();
                            response.Mensaje = mid.Mensaje;
                            response.Resultado = mid.Resultado;
                            response.Data =RGestion.Get().Find(e => e.ruta == stringruta).AccionFull.Invoke(json) ;
                            return JsonConvert.SerializeObject(response);
                        }
                        else
                            return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = mid.Mensaje });
                    }
                }else
                    return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "Esa Ruta No Existe" });
            }
            else
                return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "La ruta" });
        }

        /// <summary>
        /// Metodo Post, sirve para Enviar Datos a una ruta especifica
        /// </summary>
        /// <param name="stringruta">
        /// Recibe la ruta ya establecida
        /// </param>
        /// <param name="json">
        /// Recibe el formato Json para insertar
        /// </param>
        /// <returns name="Object">
        /// si hay una respuesta o todo esta correcto devolvera un objeto dependiendo de su backend, sino devolvera false
        /// </returns>
        public static object Post(string stringruta, string json)
        {
            if (!string.IsNullOrWhiteSpace(stringruta) && !string.IsNullOrWhiteSpace(json))
            {
                if (RGestion.IsRouteExits(Metodos.MPost, stringruta))
                {
                    var mid = (ReponseRoutesNotice)RGestion.Post().Find(e => e.ruta == stringruta).Middleware.Invoke(json);
                    if (mid.Resultado == true)
                    {
                        ReponseRoutesNotice response = new ReponseRoutesNotice();
                        response.Mensaje = mid.Mensaje;
                        response.Resultado = mid.Resultado;
                        response.Data =  RGestion.Post().Find(e => e.ruta == stringruta).Accion.Invoke(json) ;
                        return JsonConvert.SerializeObject(response);
                    }
                    else
                        return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = mid.Mensaje });
                }
                else
                    return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "Esa Ruta No Existe" });
            }
            else
                return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "La ruta o el json estan vacios" });
        }
        /// <summary>
        /// Metodo Put, sirve para modificar algun dato
        /// </summary>
        /// <param name="stringruta">
        /// Recibe la ruta ya establecida
        /// </param>
        /// <param name="json">
        /// Recibe el formato Json para actualizar los datos
        /// </param>
        /// <returns name="Object">
        /// si hay una respuesta o todo esta correcto devolvera un objeto dependiendo de su backend, sino devolvera false
        /// </returns>
        public static object Put(string stringruta, string json)
        {
           if (!string.IsNullOrWhiteSpace(stringruta) && !string.IsNullOrWhiteSpace(json))
            {
                if (RGestion.IsRouteExits(Metodos.MPut, stringruta))
                {
                    var mid = (ReponseRoutesNotice)RGestion.Put().Find(e => e.ruta == stringruta).Middleware.Invoke(json);
                    if (mid.Resultado == true)
                    {
                        ReponseRoutesNotice response = new ReponseRoutesNotice();
                        response.Mensaje = mid.Mensaje;
                        response.Resultado = mid.Resultado;
                        response.Data =RGestion.Put().Find(e => e.ruta == stringruta).Accion.Invoke(json) ;
                        return JsonConvert.SerializeObject(response);
                    }
                    else
                        return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = mid.Mensaje });
                }
                else
                    return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "Esa Ruta No Existe" });
            }
            else
                return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "La ruta o el json estan vacios" });

        }

        /// <summary>
        /// Metodo delete, sirve para eliminar algun dato
        /// </summary>
        /// <param name="stringruta">
        /// Recibe la ruta ya establecida
        /// </param>
        /// <param name="json">
        /// Recibe el formato Json para eliminar datos
        /// </param>
        /// <returns name="Object">
        /// si hay una respuesta o todo esta correcto devolvera un objeto dependiendo de su backend, sino devolvera false
        /// </returns>
        public static object Delete(string stringruta, string json)
        {
            if (!string.IsNullOrWhiteSpace(stringruta) && !string.IsNullOrWhiteSpace(json))
            {
                if (RGestion.IsRouteExits(Metodos.MDel, stringruta))
                {
                    var mid = (ReponseRoutesNotice)RGestion.Delete().Find(e => e.ruta == stringruta).Middleware.Invoke(json);
                    if (mid.Resultado == true)
                    {
                        ReponseRoutesNotice response = new ReponseRoutesNotice();
                        response.Mensaje = mid.Mensaje;
                        response.Resultado = mid.Resultado;
                        response.Data = RGestion.Delete().Find(e => e.ruta == stringruta).Accion.Invoke(json) ;
                        return JsonConvert.SerializeObject(response);
                    }
                    else
                        return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = mid.Mensaje });
                }
                else
                    return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "Esa Ruta No Existe" });
            }
            else
                return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "La ruta o el json estan vacios" });
        }

        /// <summary>
        /// DirectRoute Sirve para recibir y enviar paquetes a destinos preestablecidos
        /// </summary>
        /// <param name="stringruta">
        /// la ruta a la cual se accedera
        /// </param>
        /// <param name="paquete">
        /// El paquete que se enviara
        /// </param>
        /// <param name="To">
        /// a donde va el paquete
        /// </param>
        /// <returns>
        /// Json diciendo que el paquete ha sido entregado o algunos errores
        /// </returns>
        public static object DirectRoute(string stringruta, object paquete, Type To)
        {
            if (!string.IsNullOrWhiteSpace(stringruta) && paquete!=null && To != null)
            {
                if (RGestion.IsRouteExits(Metodos.MDestinos, stringruta))
                {
                    var ruta = RGestion.DirectRoutes().Find(e => e.ruta == stringruta);
                    if (ruta.Destinos.To == To)
                    {
                        ruta.SetPaquete(paquete);
                        return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = true, Mensaje = "Paquete Entregado" });
                    }
                    return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = true, Mensaje = "Los destinos no son iguales" });
                }
                else
                    return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "Esa Ruta No Existe" });
            }
            else
                return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "La ruta o el json estan vacios" });
        }

        /// <summary>
        /// DirectRoute Sirve para recibir y enviar paquetes a destinos preestablecidos
        /// </summary>
        /// <param name="stringruta">
        /// la ruta a la cual se accedera
        /// </param>
        /// <param name="From">
        /// de quien es el paquete
        /// </param>
        /// <returns>
        /// retorna json con el paquete o algunos errores
        /// </returns>
        public static object DirectRoute(string stringruta, Type From)
        {
            if (!string.IsNullOrWhiteSpace(stringruta) && From != null)
            {
                if (RGestion.IsRouteExits(Metodos.MDestinos, stringruta))
                {
                    var ruta = RGestion.DirectRoutes().Find(e => e.ruta == stringruta);
                    if (ruta.Destinos.From == From)
                    {
                        return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = true, Mensaje = "Los Destinos no son iguales",
                             Data = ruta.GetPaquete() });
                    }
                    return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = true, Mensaje = "Los Destinos no son iguales" });
                }
                else
                    return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "Esa Ruta No Existe" });
            }
            else
                return JsonConvert.SerializeObject(new ReponseRoutesNotice() { Resultado = false, Mensaje = "La ruta o el json estan vacios" });
        }
    }

   
}
