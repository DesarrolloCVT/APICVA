﻿using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class BancoDetalle
    {
        [Key]
        public int Id_Banco_Detalle { get; set; }
        public int Id_Banco { get; set; }
        public int Codigo_Banco { get; set; }
        public int Numero { get; set; }
        public int Saldo { get; set; }

        // Propiedad de navegación
        public Banco Bancos { get; set; }
    }
}
