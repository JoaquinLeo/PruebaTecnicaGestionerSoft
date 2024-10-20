using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Repositorio.Contrato
{
    public interface IGenericoRepositorio<TModelo> where TModelo : class
    {
        //Metodo que hace una consulta a la base de datos y retorna un modelo.
        //Es generico asi que funciona para todas los modelos que represetan las tablas de la base de datos
        //Se le puede pasar un parametro para filtrar
        IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null);

        Task<TModelo> Crear(TModelo modelo);
        Task<bool> Editar(TModelo modelo);
        Task<bool> Eliminar(TModelo modelo);
    }
}
