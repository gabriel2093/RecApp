using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecApp_2.Models
{
    public class EstadoCivil
    {
        public int id;

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Nombre")]
        public string Nombre { set; get; }


    }

  
}