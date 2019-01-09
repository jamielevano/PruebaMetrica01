using System;

namespace WebBanco.Models
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        
        public int IdBanco { get; set; }
        public string NombreBanco { get; set; }
    }
}