namespace GavilanezJhostyn_ExamenU1_AS.DTOs
{
    public class CabecerasDTO
    {
        public long Id { get; set; }
        public string Cliente { get; set; } = null!;
        public DateTime Fecha { get; set; }
        
        //Relacion
        public List<DetallesDTO> Detalles { get; set; } = new List<DetallesDTO>();

    }
}
