using System;
using System.Collections.Generic;

namespace WebApiAutos.Model.AutosDB
{
    public partial class Autos
    {
        public int IdAutos { get; set; }
        public string Color { get; set; }
        public DateTime? AñoFab { get; set; }
        public string NroPlaca { get; set; }
        public int NroAsientos { get; set; }
        public string Esmecanico { get; set; }
        public string Esfull { get; set; }
        public int IdMarca { get; set; }

        public Marca IdMarcaNavigation { get; set; }
    }
}
