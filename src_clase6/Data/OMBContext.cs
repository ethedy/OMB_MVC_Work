using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
  public class OMBContext : DbContext
  {
    public bool VerboseMode { get; set; }

    public DbSet<Persona> Personas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Perfil> Perfiles { get; set; }
    public DbSet<Libro> Libros { get; set; }

    //  no es necesario un DbSet<Perfil> porque no se estan necesitando en este momento acceder a todos los perfiles, pero
    //  no significa que en otro escenario no seria necesario (por ejemplo, alta de usuario con seleccion de perfiles)
    //  UPDATE: lo agregue para poder realizar las pruebas de crear nuevos usuarios o agregar perfiles a usuarios existentes

    public OMBContext()
      : base("Server=VALIS;Database=OMB;Trusted_Connection=true")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new UsuarioConfiguration());
      modelBuilder.Configurations.Add(new PersonaConfiguration());
      modelBuilder.Configurations.Add(new PerfilConfiguration());
      modelBuilder.Configurations.Add(new LibroConfiguration());
    }

    public void MostrarCambios(string header = null)
    {
      if (header != null)
      {
        Console.WriteLine(new string('=', header.Length));
        Console.WriteLine(header);
        Console.WriteLine(new string('=', header.Length));
      }

      //  DbEntityEntry
      foreach (var entry in ChangeTracker.Entries())
      {
        Console.WriteLine("Tipo de la entidad: {0} ; State: {1}", entry.Entity.GetType().FullName, entry.State);
      }
    }
  }

  class PersonaConfiguration : EntityTypeConfiguration<Persona>
  {
    public PersonaConfiguration()
    {
      Property(p => p.ID)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
  }

  public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
  {
    public UsuarioConfiguration()
    {
      HasKey(usr => usr.Login);

      HasRequired(usr => usr.Persona)
        .WithOptional()
        .Map(configuration => configuration.MapKey("ID_Persona"));

      HasMany(usr => usr.Perfiles)
        .WithMany()
        .Map(x =>
          {
            x.ToTable("Usuarios_Perfiles");
            x.MapLeftKey("Login");
            x.MapRightKey("ID_Perfil");
          }); 
    }
  }

  public class PerfilConfiguration : EntityTypeConfiguration<Perfil>
  {
    public PerfilConfiguration()
    {
      ToTable("Perfiles");
      Property(x => x.ID)
        .HasColumnName("ID_Perfil");
    }
  }

  public class LibroConfiguration : EntityTypeConfiguration<Libro>
  {
    public LibroConfiguration()
    {
      ToTable("Libros");
      HasKey(libro => libro.ISBN13);
      Property(libro => libro.ISBN13).HasColumnName("ISBN");
      Property(libro => libro.ISBN10).HasColumnName("ISBN_Old");
      Property(libro => libro.PathImagen).HasColumnName("Imagen");
    }
  }
}
