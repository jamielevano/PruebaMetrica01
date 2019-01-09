using System;
using System.ComponentModel.DataAnnotations;

namespace WebBanco.Models
{
    public class OrdenPago
    {
        public double Monto { get; set; }
        public string Moneda { get; set; }
        public int Estado { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaPago { get; set; }

        public int IdOrdenPago { get; set; }

        public int IdSucursal { get; set; }

        public int IdBanco { get; set; }

        public string NombreBanco { get; set; }
        public string NombreSucursal  { get; set; }


    }

    public enum EstadoPago
    {
        Pagada = 0,
        Declinada = 1,
        Fallida = 2,
        Anulada = 3
    }
}