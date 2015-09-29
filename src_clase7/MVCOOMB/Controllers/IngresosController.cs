using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Data;
using Entidades;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;

namespace MvcOMB.Controllers
{
  //  [Authorize]
  public class IngresosController : Controller
  {
    //  Action Method para un nuevo libro en blanco (retorna una vista con los campos vacios...)
    public ActionResult NewLibro()
    {
      Libro nuevoLibro = new Libro();

      return View(nuevoLibro);
    }

    public ActionResult Agregar(Libro newLibro, HttpPostedFileBase imagen)
    {
      OMBContext ctx = DB.Contexto;
      string imgPathFisica = null;

      //  ValidarModelo(newLibro);

      ValidarSoloModelo(newLibro);

      if (ModelState.IsValid)
      {
        try
        {
          if (imagen != null)
          {
            //  seteamos una imagen de no mas de 200K...
            //
            if (imagen.ContentLength > 200000)
              return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable, "El tamaño del archivo no debe superar los 200K");

            //  obtenemos la imagen y la guardamos en el directorio fisico del servidor
            //  tambien guardamos la ruta virtual para almacenarla en la DB
            //  MapPath() obtiene una ruta fisica a partir de una virtual
            //
            string fileName = Path.GetFileName(imagen.FileName);      //  el nombre del archivo del cliente

            imgPathFisica = Path.Combine(Server.MapPath("/Imagenes"), fileName);

            imagen.SaveAs(imgPathFisica);

            newLibro.PathImagen = Path.Combine("/Imagenes", fileName);
          }
          ctx.Libros.Add(newLibro);
          ctx.SaveChanges();
        }
        catch (Exception)
        {
          //  si hubo algun error borramos la imagen
          //
          if (imgPathFisica != null)
            System.IO.File.Delete(imgPathFisica);

          return new HttpUnauthorizedResult();
        }
        //  Descomentar para probar la validacion, sin tener que guardar en DB. Comentar SaveChanges()
        //  return View("NewLibro", newLibro);  

        return View();
      }
      ViewData.Model = newLibro;
      return View("NewLibro");
    }

    /// <summary>
    /// Aunque el nombre del metodo diga esto, tambien validamos el precio, dentro del rango (0, 2000]
    /// </summary>
    /// <param name="libro"></param>
    private void ValidarSoloModelo(Libro libro)
    {
      if (libro.Precio.HasValue)
      {
        if (libro.Precio <= 0 || libro.Precio > 2000)
          ModelState.AddModelError("Precio", "El valor del libro debe ser positivo y menor a $2000");
      }

      if (ModelState.IsValidField("Titulo"))
      {
        if (libro.Titulo.ToUpper().Contains("XXX"))
          ModelState.AddModelError("", "El titulo del libro no respeta las normas de la empresa");
      }
    }

    /*
        Colocar el mensaje de error para cada campo
        Poner en true el argumento del Summary para que solo muestre errores del modelo
     */
    private void ValidarModelo(Libro libro)
    {
      //  Usamos validacion explicita
      //
      if (string.IsNullOrWhiteSpace(libro.ISBN13))
        ModelState.AddModelError("ISBN13", "El campo ISBN nuevo no puede dejarse vacio!!");
      else
      {
        if (libro.ISBN13.Length != 13)
          ModelState.AddModelError("ISBN13", "El numero de identificacion ISBN debe tener exactamente 13 caracteres!!");
      }

      if (string.IsNullOrWhiteSpace(libro.Editorial))
        ModelState.AddModelError("Editorial", "Debe completar el campo Editorial");

      if (string.IsNullOrWhiteSpace(libro.Autores))
        ModelState.AddModelError("Autores", "El libro debe tener al menos un autor. Coloque un autor por cada linea");

      if (string.IsNullOrWhiteSpace(libro.Titulo))
        ModelState.AddModelError("Titulo", "Alguna vez alguien vio un libro sin titulo??");
      else
      {
        //  agregamos un error de modelo "puro" --> seria una violacion a las reglas de negocio
        //
        if (libro.Titulo.ToUpper().Contains("XXX"))
          ModelState.AddModelError("", "El titulo del libro no respeta las normas de la empresa");
      }

      if (ModelState.IsValidField("Precio"))
      {
        if (libro.Precio.HasValue && libro.Precio <= 0)
          ModelState.AddModelError("Precio", "El valor del precio debe ser un numero mayor a cero!!");
      }
    }
  }
}