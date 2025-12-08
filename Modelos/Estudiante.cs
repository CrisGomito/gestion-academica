using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Modelos;

[Table("Estudiantes", Schema = "academico")]
[Index("CodigoEstudiante", Name = "UQ__Estudian__C09683010FA48558", IsUnique = true)]
public partial class Estudiante
{
    [Key]
    public int EstudianteId { get; set; }

    [Required]
    [StringLength(20)]
    public string CodigoEstudiante { get; set; }

    [Required]
    [StringLength(120)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(120)]
    public string Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    [StringLength(150)]
    public string Email { get; set; }

    [StringLength(50)]
    public string Telefono { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public bool EsActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    [InverseProperty("Estudiante")]
    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();
}
