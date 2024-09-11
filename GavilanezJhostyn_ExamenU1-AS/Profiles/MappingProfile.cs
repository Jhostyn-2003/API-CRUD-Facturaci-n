using GavilanezJhostyn_ExamenU1_AS.DTOs;
using GavilanezJhostyn_ExamenU1_AS.Models;
using AutoMapper;

namespace GavilanezJhostyn_ExamenU1_AS.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //estos sirver para los metodos Post y PUT
            CreateMap<CabecerasDTO, Cabecera>();
            CreateMap<DetallesDTO, Detalle>();
            CreateMap<ProductosDTO, Producto>();

            //reversa sirven para las consultas 
            CreateMap<Detalle, DetallesDTO>();

        }
    }
}
