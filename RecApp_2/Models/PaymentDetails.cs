using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecApp_2.Models
{
    public class PaymentDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Cobro por Tratamiento")]
        public int IdCobro { get; set; }

        [Display(Name = "Fecha de Abono")]
        [Required(ErrorMessage = "Campo requerido*")]
        public DateTime FechaAbono{ get; set; } = DateTime.Now;

        [NotMapped]
        [Display(Name = "Estado Pago")]
        public int Estado { get; set; }


        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DataType(DataType.Currency)]
        public decimal? Abono { get; set; }
    }
}