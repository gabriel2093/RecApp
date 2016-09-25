using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecApp_2.Models
{
    public class Record
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]        
        [Display(Name = "Nombre")]
        public string Nombre { set; get; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Apellido 1")]
        public string Apellido1 { set; get; }


        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Apellido 2")]
        public string Apellido2 { set; get; }

        [Required(ErrorMessage = "Campo requerido*")]
        [DataType(DataType.Duration, ErrorMessage = "Ingrese un número de identificación válida.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        [Display(Name = "Cédula de Identidad")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        //[DataType(DataType.DateTime, ErrorMessage = "Ingrese una fecha válida."), DisplayFormat(DataFormatString = "{0:dd.MM.yy}") ]
        [DataType(DataType.DateTime, ErrorMessage = "Ingrese una fecha válida.")]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        
        //[DataType(DataType.Duration, ErrorMessage = "Ingrese un número de identificación válida.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Display(Name = "Menor de edad")]
        public int MenorEdad { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Encargado")]
        public string NombreEncargado { set; get; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Apellido 1")]
        public string Apellido1Encargado { set; get; }


        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Apellido 2")]
        public string Apellido2Encargado { set; get; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Estado civil")]
        public  int IdEstadoCivil { get; set; }
       


        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Domicilio")]
        public string Domicilio { set; get; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Teléfono domicilio")]
        public string Telefono1 { set; get; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Celular")]
        public string Telefono2 { set; get; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Profesión")]
        public string Profesion { set; get; }


        [Required(ErrorMessage = "Campo requerido*")]
        [EmailAddress(ErrorMessage = "Formato de correo incorrecto*")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Contacto de emergencia")]
        public string ContactoEmergencia { set; get; }

        //Condiciones Medicas
        [Display(Name = "Esta bajo tratamiento médico")]
        public bool TratamientoMedico { get; set; }
        
        [Display(Name = "Toma algún medicamento")]
        public bool Medicamento { get; set; }

        [Display(Name = "Diabetes Mellitus")]
        public bool Diabetes { get; set; }

        [Display(Name = "Artritis")]
        public bool Artritis{ get; set; }

        [Display(Name = "Enfermedades cardiacas")]
        public bool EnfermedadCardiaca { get; set; }

        [Display(Name = "Hepatitis")]
        public bool Hepatitis { get; set; }

        [Display(Name = "Fiebre reumática")]
        public bool FiebreReumatica { get; set; }

        [Display(Name = "Úlceras")]
        public bool Ulcera { get; set; }

        [Display(Name = "Presión arterial alta")]
        public bool PresionAlta { get; set; }

        [Display(Name = "Presión arterial baja")]
        public bool PresionBaja { get; set; }

        [Display(Name = "Enfermedades Nerviosas")]
        public bool EnfermedadesNerviosas { get; set; }


        [Display(Name = "Otras Enfermedades")]
        public bool OtrasEnfermedades { get; set; }


        [Display(Name = "Sangrado prolongado")]
        public bool SangradoProlongado { get; set; }

      
        [Display(Name = "Desmayos")]
        public bool Desmayos { get; set; }

        [Display(Name = "Intervención Quirúrgica")]
        public bool IntervencionQuirurgica { get; set; }


        [Display(Name = "Aspirina")]
        public bool Aspirina { get; set; }

        [Display(Name = "Sulfas")]
        public bool Sulfas { get; set; }

        [Display(Name = "Penicilina")]
        public bool Penicilina { get; set; }     

        [Display(Name = "Anomalías con anestesia dental")]
        public bool AnomaliasAnestesia { get; set; }

        [Display(Name = "Está embaraza")]
        public bool Embarazo { get; set; }

        [Display(Name = "Periodo lactancia")]
        public bool Lactancia { get; set; }

        [Display(Name = "Otros")]
        public string Otros { get; set; }

    }
}