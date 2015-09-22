using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Entidades
{
  public class Libro
  {
    [Required(ErrorMessage = "El campo ISBN debe estar completo", AllowEmptyStrings = false)]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "El ISBN debe ser exactamente de 13 caracteres")]
    public string ISBN13 { get; set; }

    public string ISBN10 { get; set; }

    public string Editorial { get; set; }

    [Required(ErrorMessage = "Alguna vez viste un libro sin titulo???")]
    public string Titulo { get; set; }

    public string Subtitulo { get; set; }

    /// <summary>
    /// Puede ser Primera, Primera Revisada, etc...por eso no pongo numerico...
    /// </summary>
    public string Edicion { get; set; }

    /// <summary>
    /// Obviamente hay que pasarla a una coleccion que referencie a otra entidad...
    /// </summary>
    public string Autores { get; set; }

    [Range(typeof(decimal), "0,01", "1500")]
    public decimal? Precio { get; set; }

    public string PathImagen { get; set; }
  }
}
