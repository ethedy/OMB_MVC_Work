using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Servicios;

namespace MvcOMB.Models
{
  /// <summary>
  /// Usamos esta clase para que la vista pueda acceder facilmente a las opciones de menu de cada usuario
  /// sin tener que implementar tanta logica
  /// </summary>
  public class MainMenuViewModel
  {
    private Sesion _sesion;

    public MainMenuViewModel(Sesion sesionActual)
    {
      _sesion = sesionActual;
    }

    /// <summary>
    /// Si la Sesion es null, significa que no hay usuario autenticado...
    /// </summary>
    public bool IsUserLoged
    {
      get { return _sesion != null; }
    }

    //  Version 1: un menu simple, la vista deberia decidir como armar la ruta o el action link de destino
    //
    public IEnumerable<string> GetMenuApropiado()
    {
      IEnumerable<string> result = null;

      //  por las dudas que la sesion sea nula...
      if (_sesion != null)
      {
        switch (_sesion.Perfil.Nombre)
        {
          case "PDV":
            result = new List<string>() {"Abrir Caja", "Iniciar Venta", "Buscar"};
            break;

          case "AsistenciaCliente":
          case "SysAdmin":
            result = new List<string>() {"Listados", "Busquedas"};
            break;
        }
      }
      return result;
    }

    //  Version 2: retorno una coleccion de elementos que tambien sirven a la vista para direccionar el proximo request
    //
    public IEnumerable<MenuInfo> GetMenuApropiadoFull()
    {
      IEnumerable<MenuInfo> result = null;

      //  por las dudas que la sesion sea nula...
      if (_sesion != null)
      {
        switch (_sesion.Perfil.Nombre)
        {
          case "PDV":
            result = new List<MenuInfo>()
            {
              new MenuInfo() { Etiqueta = "Abrir Caja", Accion = "OpenCaja"}, 
              new MenuInfo() { Etiqueta = "Iniciar Venta", Accion = "Venta"},
              new MenuInfo() { Etiqueta = "Buscar", Accion = "Search", Controlador = "Common"}
            };
            break;

          case "AsistenciaCliente":
          case "SysAdmin":
            result = new List<MenuInfo>()
            {
              new MenuInfo() { Etiqueta = "Listados", Accion = "List", Controlador = "Listados"},
              new MenuInfo() { Etiqueta = "Busquedas", Accion = "Search", Controlador = "Common"}
            };
            break;
        }
      }
      return result;
    }
  }
}