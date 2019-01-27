using WebApiAutos.Model.VehiculoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAutos.Model.Repositories
{
    public interface IProyectoRepository
    {
        IQueryable<TMarca> Marcas { get; }
        Task SaveProject(TMarca marca);
        void DeleteProyecto(Guid MarcaId);
    }
}
