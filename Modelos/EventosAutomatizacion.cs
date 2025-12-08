using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Modelos;

[Table("EventosAutomatizacion", Schema = "academico")]
[Index("FechaEvento", Name = "IX_Eventos_FFecha")]
public partial class EventosAutomatizacion
{
    [Key]
    public int EventoId { get; set; }

    public DateTime FechaEvento { get; set; }

    [Required]
    [StringLength(3)]
    public string Direccion { get; set; }

    [StringLength(20)]
    public string Puerto { get; set; }

    [Required]
    [StringLength(500)]
    public string Mensaje { get; set; }

    [StringLength(50)]
    public string Tipo { get; set; }

    public bool Procesado { get; set; }
}
