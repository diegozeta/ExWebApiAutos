using WebApiAutos.Model.AutosDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAutos.Model.Repositories
{
    public interface IAutoRepository
    {
        IQueryable<TAuto> Autos { get; }
        Task SaveAuto(TAuto Auto);
        void DeleteAuto(Guid AutoId);
    }
}
