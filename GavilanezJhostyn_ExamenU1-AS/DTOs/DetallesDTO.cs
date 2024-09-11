namespace GavilanezJhostyn_ExamenU1_AS.DTOs
{
    public class DetallesDTO
    {
        public long Id { get; set; }
        public long CabeceraId { get; set; }
        public long ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
       //Relacion 
        //public ProductosDTO Producto { get; set; } = null!;

    }
}
