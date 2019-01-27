using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiAutos.Model.Repositories;
using WebApiAutos.Model.VehiculoDb;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAutos.Controllers
{
    [Route("api/[controller]")]
    public class VehiculoController : Controller
    {
        private IVehiculoRepository repositorio;
        public VehiculoController(IVehiculoRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TVehiculo> Get()
        {
            return repositorio.Vehiculos;
        }
        // GET api/<controller>/5
        [HttpGet("{VehiculoId}")]
        public TVehiculo Get(Guid VehiculoId)
        {
            return repositorio.Vehiculos.Where(p => p.VehiculoId == VehiculoId).FirstOrDefault();
        }
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TVehiculo vehiculo)
        {
            await repositorio.SaveVehiculo(vehiculo);
            return Ok(true);
        }
        // PUT api/<controller>/5
        [HttpPut("{VehiculoId}")]
        public async Task<IActionResult> Put(Guid VehiculoId, [FromBody]TVehiculo vehiculo)
        {
            vehiculo.VehiculoId = VehiculoId;
            await repositorio.SaveVehiculo(vehiculo);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{VehiculoId}")]
        public IActionResult Delete(Guid VehiculoId)
        {
            repositorio.DeleteVehiculo(VehiculoId);
            return Ok(true);
        }
    }
}
