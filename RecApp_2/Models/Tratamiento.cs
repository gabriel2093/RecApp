using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        
        [NotMapped]
        public string NombreCompuesto { set; get; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "El precio no puede tener más de dos decimales.")]
        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Precio Base")]
        public decimal PrecioBase { get; set; }
    }
}