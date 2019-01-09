using System;
using System.Runtime.Serialization;

namespace WebBanco.Models
{

    [DataContract]
    public class SucursalData 
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public int Id { get; set; }
        public int IdBanco { get; set; }

    }
}