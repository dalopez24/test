using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.ViewModels
{
    public class LoginViewModel
    {
        public string usuario { get;set;}
        [DataType(DataType.Password)]
        public string contraseña { get; set;}
    }
}