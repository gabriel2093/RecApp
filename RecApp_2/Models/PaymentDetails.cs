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
        [Display(Name = "Num. Factura")]
        public int IdPayment { get; set; }

        [Display(Name = "Fecha de abono")]
        [Required(ErrorMessage = "Campo requerido*")]
        public DateTime FechaAbono{ get; set; } = DateTime.Now;

        
        [Display(Name = "Estado del abono")]
        public int Estado { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Monto del abono")]       
        public decimal Abono { get; set; }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Saldo pendiente")]
        public decimal Saldo { get; set; }

    }
}