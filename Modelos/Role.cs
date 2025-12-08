using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Modelos;

[Table("Roles", Schema = "academico")]
[Index("NombreRol", Name = "UQ_Rol_Nombre", IsUnique = true)]
public partial class Role
{
    [Key]
    public int RolId { get; set; }

    [Required]
    [StringLength(80)]
    public string NombreRol { get; set; }

    [StringLength(200)]
    public string Descripcion { get; set; }

    [ForeignKey("RolId")]
    [InverseProperty("Rols")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
