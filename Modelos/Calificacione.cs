using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Modelos;

[Table("Calificaciones", Schema = "academico")]
[Index("FechaEvaluacion", Name = "IX_Calificaciones_Fecha")]
[Index("InscripcionId", Name = "IX_Calificaciones_Inscripcion")]
public partial class Calificacione
{
    [Key]
    public int CalificacionId { get; set; }

    public int InscripcionId { get; set; }

    [StringLength(150)]
    public string NombreEvaluacion { get; set; }

    public DateOnly FechaEvaluacion { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Nota { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Peso { get; set; }

    [StringLength(400)]
    public string Comentario { get; set; }

    [ForeignKey("InscripcionId")]
    [InverseProperty("Calificaciones")]
    public virtual Inscripcione Inscripcion { get; set; }
}
