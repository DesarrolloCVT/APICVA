﻿using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class CuentasDTO
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
    }
}
