using System;

namespace WebBanco.Models
{
    public class Banco
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Id { get; set; }
    }
}