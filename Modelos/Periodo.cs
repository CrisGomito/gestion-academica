using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Modelos;

[Table("Periodos", Schema = "academico")]
public partial class Periodo
{
    [Key]
    public int PeriodoId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public bool EsActivo { get; set; }

    [InverseProperty("Periodo")]
    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
