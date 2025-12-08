using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Modelos;

[Table("Cursos", Schema = "academico")]
[Index("MateriaId", "PeriodoId", Name = "IX_Cursos_Materia_Periodo")]
public partial class Curso
{
    [Key]
    public int CursoId { get; set; }

    public int MateriaId { get; set; }

    public int PeriodoId { get; set; }

    [StringLength(60)]
    public string CodigoCurso { get; set; }

    [StringLength(200)]
    public string Docente { get; set; }

    public int? CupoMaximo { get; set; }

    [InverseProperty("Curso")]
    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    [ForeignKey("MateriaId")]
    [InverseProperty("Cursos")]
    public virtual Materia Materia { get; set; }

    [ForeignKey("PeriodoId")]
    [InverseProperty("Cursos")]
    public virtual Periodo Periodo { get; set; }
}
