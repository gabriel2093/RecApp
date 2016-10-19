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

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Tratamiento")]
        public int IdTratamiento { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Cédula paciente")]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "# diente")]
        public int IdDiente { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Cara diente")]
        public string Cara { get; set; }

        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

        [NotMapped]
        public IEnumerable<Tratamiento> ListTratamiento { get; set; }
    }
}