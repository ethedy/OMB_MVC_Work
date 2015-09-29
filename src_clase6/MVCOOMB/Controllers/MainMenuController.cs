using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using MvcOMB.Models;
using Servicios;

namespace MvcOMB.Controllers
{
  public class MainMenuController : Controller
  {
    // GET: MainMenu
    public PartialViewResult Menu(string menuActual = null)
    {
      MainMenuViewModel vm = new MainMenuViewModel(Session["SESION_USER"] as Sesion);
      if (menuActual != null)
        ViewBag.MenuActual = menuActual;

      return PartialView(vm);
    }

    public PartialViewResult EditarLibro(Libro entidad)
    {
      Sesion ses = Session["SESION_USER"] as Sesion;

      ViewBag.Habilitar = false;

      if (ses != null)
      {
        if (ses.Perfil.Nombre.Contains("Admin") && entidad.Precio.Value < 30)
          ViewBag.Habilitar = true;
      }
      return PartialView();
    }
  }
}