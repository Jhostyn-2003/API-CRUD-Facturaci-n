using System;
using System.Collections.Generic;

namespace GavilanezJhostyn_ExamenU1_AS.Models;

public partial class Detalle
{
    public long Id { get; set; }

    public long CabeceraId { get; set; }

    public long ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Cabecera Cabecera { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
