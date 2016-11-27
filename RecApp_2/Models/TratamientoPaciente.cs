using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecApp_2.Models
{
    public class TratamientoPaciente
    {
        public int Id { get; set; }
        
        public int IdPayment { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Tratamiento")]
        public int IdTratamiento { get; set; }

        
        [NotMapped]
        [Display(Name = "Tratamiento")]
        public string Tratamiento { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Cédula paciente")]
        public int IdPaciente { get; set; }

        [NotMapped]
        [Display(Name = "Nombre del paciente")]
        public string NombrePaciente { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "No. Diente")]
        public int IdDiente { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Cara diente")]
        public string Cara { get; set; }

        [Display(Name = "Detalles")]
        public string Observaciones { get; set; }

        [Display(Name = "Fecha del tratamiento")]
        [Required(ErrorMessage = "Campo requerido*")]        
        public DateTime FechaTratamiento { get; set; } =  DateTime.Now;

        [NotMapped]
        [Display(Name = "Costo")]
        public decimal Costo { get; set; }

        [NotMapped]
        [Display(Name = "Monto(s) Adicional(es)")]
        public decimal MontoAdicional { get; set; }

        [NotMapped]
        [Display(Name = "Total")]
        public decimal? Total { get; set; }

        [NotMapped]        
        public Payment _Payment { get; set; }

        [NotMapped]
        public IEnumerable<Tratamiento> ListTratamiento { get; set; }

    }
}