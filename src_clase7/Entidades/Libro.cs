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
    [Required(AllowEmptyStrings = false, ErrorMessage = "El campo ISBN nuevo no puede dejarse vacio!!")]
    [StringLength(maximumLength: 13, MinimumLength = 13, ErrorMessage = "El numero de identificacion ISBN debe tener exactamente 13 caracteres!!")]
    public string ISBN13 { get; set; }

    public string ISBN10 { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Debe completar el campo Editorial")]
    public string Editorial { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Alguna vez alguien vio un libro sin titulo??")]
    public string Titulo { get; set; }

    public string Subtitulo { get; set; }

    /// <summary>
    /// Puede ser Primera, Primera Revisada, etc...por eso no pongo numerico...
    /// </summary>
    public string Edicion { get; set; }

    /// <summary>
    /// Obviamente hay que pasarla a una coleccion que referencie a otra entidad...
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "El libro debe tener al menos un autor. Coloque un autor por cada linea")]
    public string Autores { get; set; }

    //  Eliminamos temporalmente la validcion del valor decimal por problemas de globalizacion
    //  Solo hacemos validacion en el servidor
    //
    //  [Range(typeof(decimal), "0", "1500", ErrorMessage = "El valor del precio debe ser un numero mayor a cero y menor a 1500!!")]
    public decimal? Precio { get; set; }

    public string PathImagen { get; set; }
  }
}
