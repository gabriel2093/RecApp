using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecApp_2.Models
{
    public class Tratamiento
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Nombre")]
        public string Nombre { set; get; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Descripción")]
        public string Descripcion { set; get; }


        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Campo requerido*")]
        public decimal? PrecioBase { get; set; }
    }
}