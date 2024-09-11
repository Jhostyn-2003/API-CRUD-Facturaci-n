using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GavilanezJhostyn_ExamenU1_AS.Models;

public partial class Producto
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    [JsonIgnore]
    public virtual ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();
}
