﻿using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class SocioNegocio
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Saldo { get; set; }
    }
}
