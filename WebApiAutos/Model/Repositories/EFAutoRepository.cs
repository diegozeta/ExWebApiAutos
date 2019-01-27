using WebApiAutos.Model.AutosDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAutos.Model.Repositories
{
    public class EFAutoRepository : IAutoRepository
    {
        public IQueryable<TAuto> Autos => context.TAuto;
        private AutosDbContext context;
        public EFAutoRepository(AutosDbContext ctx)
        {
            context = ctx;
        }
        public async Task SaveAuto(TAuto Auto)
        {
            if (Auto.AutoId == Guid.Empty)
            {
                Auto.AutoId = Guid.NewGuid();
                context.TAuto.Add(Auto);
            }
            else
            {
                TAuto dbEntry = context.TAuto
                .FirstOrDefault(p => p.AutoId == Auto.AutoId);
                if (dbEntry != null)
                {
                    dbEntry.AutoColor = Auto.AutoColor;
                    dbEntry.AutoAnioFabri = Auto.AutoAnioFabri;
                    dbEntry.AutoPlaca = Auto.AutoPlaca;
                    dbEntry.AutoNroAsientos = Auto.AutoNroAsientos;
                    dbEntry.AutoMecanico = Auto.AutoMecanico;
                    dbEntry.AutoFull = Auto.AutoMecanico;
                    dbEntry.MarcaId = Auto.MarcaId;
                }
            }
            await context.SaveChangesAsync();
        }
        public void DeleteAuto(Guid AutoId)
        {
            TAuto dbEntry = context.TAuto
            .FirstOrDefault(p => p.AutoId == AutoId);
            if (dbEntry != null)
            {
                context.TAuto.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
