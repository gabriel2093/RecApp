using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecApp_2.Models
{
    public class CivilStatus
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Nombre")]
        public string Descripcion { get; set; }


    }
}