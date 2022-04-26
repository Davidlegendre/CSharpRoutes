# CSharpRoutes
CSharpRoutes es una libreria para crear rutas al estilo Express pero orientado al desarrollo desktop

## Getting Started

Solo Clone el repositorio y compilelo en visual studio para obtener el dll

### Prerequisites

Tener Visual Studio ovbiamente

### Creando Rutas

Una vez compilado y haber referenciado el dll, puede usarlo añadiendo el using
```
using CSharpRoutes.lib;
```
En CSharpRoutes.lib, podemos encontrar a:
-  Middlewares con la clase MW (MiddleWares)
-  MRoutes que contiene las clases Get, Post, Put, Delete
-  Responses donde esta ResponseRoutesNotice que es el objeto que devuelve cada ruta
-  Gestiones con las clases: RGestion para Gestionar las rutas como agregar y saber si ya existe una y RMethod que contiene los metodos para consultas a las rutas
-  Helpers con las clases: ComparerRoutes (uso interno se encarga de comparar las rutas), Metodos (Enum)
-  Clase Rutas que contiene la base

-  Para Crear Rutas puede seguir el ejemplo
-  Para Get, si se quiere solo enviar datos use solo Accion, pero si quiere enviar y recibir datos use AccionFull
```
RGestion.Get(new Get() { ruta = "nombre de la ruta", 
Middleware = /objeto tipo Middleware/,
Accion = () => { /funcion que retorne un object, no recibe nada/, 
AccionFull = (obj)=>{ /funcion que retorne un object y recibe un object que puede ser un json o un objeto normal/ } } 
});
```

Para Post
```
RGestion.Post(new Post() { ruta = "nombre de la ruta", 
Middleware = /objeto tipo Middleware/,
Accion = (obj)=>{ /funcion que recibe y envia un object/ } }
 });
```

Para Put
```
RGestion.Put(new Put() { ruta = "nombre de la ruta", 
Middleware = /objeto tipo Middleware/,
Accion = (obj)=>{ /funcion que recibe y envia un object/ } }
 });
```

Para Delete
```
RGestion.Delete(new Delete() { ruta = "nombre de la ruta", 
Middleware = /objeto tipo Middleware/,
Accion = (obj)=>{ /funcion que recibe y envia un object/ } }
 });
```

-  Para todas las rutas si usa un Accion (AccionFull para Get), tendra que usar Middleware, le sera mas facil si envia json's.
-  En los Middlewares puede concatenarlo como en express hasta llegar al metodo ultimo Next()

## Obteniendo Rutas

Para obtener Rutas solo llame a RMethod
```
RMethod.Get(string ruta, object? json = null)
```
si desea enviar json en Get puede hacerlo, sino, no use el parametro json

```
RMethod.Post(string ruta, object json)
```
```
RMethod.Put(string ruta, object json)
```
```
RMethod.Delete(string ruta, object json)
```

Todos devuelven un json que tiene estos campos en c#
```
public class ReponseRoutesNotice
{
    public bool Resultado
    public string? Mensaje
    public object? Data
}
```
-  Resultado es booleano indica si es exitoso o no
-  Mensaje contiene el mensaje dado por la libreria o por el BackEnd cuando se trata de Middlewares().IsPersonalizado
-  Data es un objeto que contiene los datos devueltos por la libreria o por el BackEnd
-  La clase esta disponible tambien en la libreria no tiene que crear uno, solo asegurese de escribirlo bien e instanciarlo

Si quiere obtener solo el Data, use esto
```
RGestion.GetData(object json);
```
ejemplo:
```
RGestion.GetData(RGestion.Get("/GetUsers"));
```

Si quiere consultar las otras propiedades puede usar estos
```
RGestion.GetMensaje(object json);
```
```
RGestion.GetResultado(object json);
```

## Built With

* [Visual Studio](https://visualstudio.microsoft.com/es/) - Visual Studio


## Authors

* **David Legendre** - *Initial work* - [Perfil](https://github.com/Davidlegendre)

## License

This project is OpenSource
