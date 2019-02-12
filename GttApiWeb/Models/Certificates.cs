using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GttApiWeb.Models
{
    public class Certificates
    {
        public long id { get; set; }
        public string alias { get; set; }
        public string entidadEmisora { get; set; }
        public string numeroSerie { get; set; }
        public string subject { get; set; }
        public DateTime fechaCaducidad { get; set; }
        public string password { get; set; }
        public long idOrga { get; set; }
        public string nombreCliente { get; set; }
        public string listaIntegraciones { get; set; }
        public string email { get; set; }
        public string repositorio { get; set; }
        public string observaciones { get; set; }
        public bool eliminado { get; set; }
        public string fichero64 { get; set; }
        public string nombreArchivo { get; set; }

    }
}
