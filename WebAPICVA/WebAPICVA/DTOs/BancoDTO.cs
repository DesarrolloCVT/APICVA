﻿using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class BancoDTO
    {
        [Key]
        public int Id_Banco { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
