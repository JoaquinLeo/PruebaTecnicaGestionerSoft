using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Modelo;
using PruebaTecnica.DTO;
using PruebaTecnica.Repositorio.Contrato;
using PruebaTecnica.Servicio.Contrato;
using AutoMapper;

namespace PruebaTecnica.Servicio.Implementacion
{
    public class DeportistaServicio : IDeportistaServicio
    {
        private readonly IGenericoRepositorio<Deportista> _modeloRepositorio;
        private readonly IMapper _mapper;

        public DeportistaServicio(IGenericoRepositorio<Deportista> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<DeportistaDTO> Crear(DeportistaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Deportista>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdDeporte != 0)
                {
                    return _mapper.Map<DeportistaDTO>(rspModelo);
                }
                else
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(DeportistaDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdDeportista == modelo.IdDeportista);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Apellido = modelo.Apellido;
                    fromDbModelo.Edad = modelo.Edad;
                    fromDbModelo.Sexo = modelo.Sexo;
                    fromDbModelo.IdNacionalidad = modelo.IdNacionalidad;
                    fromDbModelo.IdDeporte = modelo.IdDeporte;
                    fromDbModelo.Imagen = modelo.Imagen;

                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (respuesta)
                    {
                        return respuesta;
                    }
                    else
                    {
                        throw new TaskCanceledException("No se pudo editar");
                    }
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdDeportista == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _modeloRepositorio.Eliminar(fromDbModelo);

                    if (respuesta)
                    {
                        return respuesta;
                    }
                    else
                    {
                        throw new TaskCanceledException("No se pudo eliminar");
                    }
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DeportistaDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                string.Concat(p.Nombre.ToLower(),p.Apellido.ToLower()).Contains(buscar.ToLower())
                ).Include(d => d.IdDeporteNavigation ).Include(n => n.IdNacionalidadNavigation);


                List<DeportistaDTO> lista = _mapper.Map<List<DeportistaDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeportistaDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdDeportista == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<DeportistaDTO>(fromDbModelo);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
