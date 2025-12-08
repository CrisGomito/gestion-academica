using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Modelos;

[Table("Materias", Schema = "academico")]
[Index("Codigo", Name = "UQ__Materias__06370DAC9822F1D4", IsUnique = true)]
public partial class Materia
{
    [Key]
    public int MateriaId { get; set; }

    [Required]
    [StringLength(30)]
    public string Codigo { get; set; }

    [Required]
    [StringLength(200)]
    public string Nombre { get; set; }

    public int Creditos { get; set; }

    public bool EsActiva { get; set; }

    [InverseProperty("Materia")]
    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
