using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.ViewModels
{
    public class UsuarioViewModel
    {
        public string Nombre { get; set; }
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        public string Genero { get; set; }
        public bool Estado { get; set; }
    }
}