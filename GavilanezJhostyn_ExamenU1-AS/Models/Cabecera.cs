using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GavilanezJhostyn_ExamenU1_AS.Models;

public partial class Cabecera
{
    public long Id { get; set; }

    public string Cliente { get; set; } = null!;

    public DateTime Fecha { get; set; }

    [JsonIgnore]
    public virtual ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();
}
