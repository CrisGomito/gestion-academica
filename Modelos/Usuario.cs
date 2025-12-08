using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gestion_Academica.Modelos;

[Table("Usuarios", Schema = "academico")]
[Index("NombreUsuario", Name = "UQ_Usuario_Nombre", IsUnique = true)]
public partial class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    [Required]
    [StringLength(80)]
    public string NombreUsuario { get; set; }

    [StringLength(100)]
    public string Apellidos { get; set; }

    [Required]
    [StringLength(300)]
    public string PasswordHash { get; set; }

    [StringLength(150)]
    public string Email { get; set; }

    public bool EsActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    [ForeignKey("UsuarioId")]
    [InverseProperty("Usuarios")]
    public virtual ICollection<Role> Rols { get; set; } = new List<Role>();
    
    //No se envía a la base de datos
    [NotMapped]
    [DisplayName("Nombre Completo")]
    public string NombreCompleto
    {
        get
        {
            return $"{NombreUsuario} {Apellidos}".Trim();
        }

    }
}
