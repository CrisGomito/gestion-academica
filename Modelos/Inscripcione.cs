using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Modelos;

[Table("Inscripciones", Schema = "academico")]
[Index("CursoId", Name = "IX_Inscripciones_Curso")]
[Index("EstudianteId", Name = "IX_Inscripciones_Estudiante")]
[Index("EstudianteId", "CursoId", Name = "UQ_Inscripcion", IsUnique = true)]
public partial class Inscripcione
{
    [Key]
    public int InscripcionId { get; set; }

    public int EstudianteId { get; set; }

    public int CursoId { get; set; }

    public DateTime FechaInscripcion { get; set; }

    [Required]
    [StringLength(50)]
    public string Estado { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? PromedioActual { get; set; }

    [Column(TypeName = "decimal(5, 4)")]
    public decimal? ProbabilidadRiesgo { get; set; }

    [InverseProperty("Inscripcion")]
    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    [ForeignKey("CursoId")]
    [InverseProperty("Inscripciones")]
    public virtual Curso Curso { get; set; }

    [ForeignKey("EstudianteId")]
    [InverseProperty("Inscripciones")]
    public virtual Estudiante Estudiante { get; set; }
}
