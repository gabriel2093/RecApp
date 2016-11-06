using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace RecApp_2.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Paciente")]
        public int IdRecord { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Fecha de Facturación")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Estado Factura")]
        public int Estado { get; set; }

        [NotMapped]
        [Display(Name = "Tratamiento")]
        public string  Tratamiento { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DataType(DataType.Currency)]
        [DefaultValue(0)]
        public decimal MontoAdicional { get; set; }


        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Total a pagar")]
        [DataType(DataType.Currency)]
        public decimal? TotalPagar { get; set; }

        [NotMapped]
        [Display(Name = "Nombre del paciente")]
        public string NombrePaciente { get; set; }


        [NotMapped]
        public IEnumerable<TratamientoPaciente> ListTratamientoXPaciente { get; set; }

        [NotMapped]
        public IEnumerable<PaymentDetails> ListPaymentDetails{ get; set; }

    }
}