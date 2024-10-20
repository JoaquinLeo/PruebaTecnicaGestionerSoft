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
    public class NacionalidadServicio : INacionalidadServicio
    {
        private readonly IGenericoRepositorio<Nacionalidad> _modeloRepositorio;
        private readonly IMapper _mapper;

        public NacionalidadServicio(IGenericoRepositorio<Nacionalidad> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<NacionalidadDTO> Crear(NacionalidadDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Nombre == modelo.Nombre);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo == null) 
                {
                    var dbModelo = _mapper.Map<Nacionalidad>(modelo);

                    var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                    if (rspModelo.IdNacionalidad != 0)
                    {
                        return _mapper.Map<NacionalidadDTO>(rspModelo);
                    }
                    else
                    {
                        throw new TaskCanceledException("No se pudo crear");
                    }
                }
                else
                {
                    throw new TaskCanceledException("Ya existe la nacionalidad");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(NacionalidadDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdNacionalidad == modelo.IdNacionalidad);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();
                
                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdNacionalidad == id);
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

        public async Task<List<NacionalidadDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower())
                );


                List<NacionalidadDTO> lista = _mapper.Map<List<NacionalidadDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NacionalidadDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdNacionalidad == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<NacionalidadDTO>(fromDbModelo);
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
