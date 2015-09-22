using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidades;
using Data;

namespace MvcOMB.Controllers
{
  public class IngresosController : Controller
  {
    // GET: Ingresos
    public ActionResult Nuevo()
    {
      Libro nuevoLibro = new Libro();

      return View(nuevoLibro);
    }

    [HttpPost]
    public ActionResult AddNew(Libro nuevoLibro)
    {
      OMBContext ctx = DB.Contexto;

      //  ValidarModelo(nuevoLibro);

      ValidarModeloSolo(nuevoLibro);
      
      if (ModelState.IsValid)
      {
        try
        {
          ctx.Libros.Add(nuevoLibro);
          ctx.SaveChanges();

          return View("Resultado");
        }
        catch (Exception ex)
        {
          return new HttpUnauthorizedResult();
        }
      }
      else
        return View("Nuevo", nuevoLibro);
    }

    private void ValidarModelo(Libro libro)
    {
      if (string.IsNullOrEmpty(libro.ISBN13))
        ModelState.AddModelError("ISBN13", "El campo ISBN debe estar completo");
      
      if (string.IsNullOrEmpty(libro.Titulo))
        ModelState.AddModelError("Titulo", "Alguna vez viste un libro sin titulo???");
      else
      {
        if (libro.Titulo.ToUpper().Contains("XXX"))
          ModelState.AddModelError("", "Esta libreria es bastante decente!!!");
      }
    }

    private void ValidarModeloSolo(Libro libro)
    {
      if (ModelState.IsValidField("Titulo"))
      {
        if (libro.Titulo.ToUpper().Contains("XXX"))
          ModelState.AddModelError("", "Esta libreria es bastante decente!!!");
      }
    }
  }
}