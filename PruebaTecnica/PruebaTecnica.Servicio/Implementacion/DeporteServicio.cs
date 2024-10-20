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
    public class DeporteServicio : IDeporteServicio
    { 
        private readonly IGenericoRepositorio<Deporte> _modeloRepositorio;
        private readonly IMapper _mapper;

        public DeporteServicio(IGenericoRepositorio<Deporte> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<DeporteDTO> Crear(DeporteDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Nombre == modelo.Nombre);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo == null)
                {
                    var dbModelo = _mapper.Map<Deporte>(modelo);

                    var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                    if (rspModelo.IdDeporte != 0)
                    {
                        return _mapper.Map<DeporteDTO>(rspModelo);
                    }
                    else
                    {
                        throw new TaskCanceledException("No se pudo crear");
                    }
                }
                else
                {
                    throw new TaskCanceledException("Ya existe el deporte");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(DeporteDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdDeporte == modelo.IdDeporte);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Tipo = modelo.Tipo;
                    fromDbModelo.Descripcion = modelo.Descripcion;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdDeporte == id);
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

        public async Task<List<DeporteDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower())
                );


                List<DeporteDTO> lista = _mapper.Map<List<DeporteDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeporteDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdDeporte == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<DeporteDTO>(fromDbModelo);
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
