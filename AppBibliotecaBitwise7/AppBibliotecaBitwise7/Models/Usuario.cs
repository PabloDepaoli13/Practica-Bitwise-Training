﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise7.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public string NombreUsuario { get; set; }

        public string Nombre { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } 
    }
}
