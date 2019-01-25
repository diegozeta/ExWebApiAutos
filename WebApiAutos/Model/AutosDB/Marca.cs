using System;
using System.Collections.Generic;

namespace WebApiAutos.Model.AutosDB
{
    public partial class Marca
    {
        public Marca()
        {
            Autos = new HashSet<Autos>();
        }

        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }

        public ICollection<Autos> Autos { get; set; }
    }
}
