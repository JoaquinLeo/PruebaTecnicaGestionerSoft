using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using PruebaTecnica.DTO;
using PruebaTecnica.Modelo;

namespace PruebaTecnica.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Deporte,DeporteDTO>();
            CreateMap<DeporteDTO, Deporte>();

            CreateMap<Nacionalidad,NacionalidadDTO>();
            CreateMap<NacionalidadDTO, Nacionalidad>();

            CreateMap<Deportista, DeportistaDTO>();
            CreateMap<DeportistaDTO, Deportista>();
        }
    }
}
