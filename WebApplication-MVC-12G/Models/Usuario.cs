﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_MVC_12G.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [MinLength(7, ErrorMessage = ErrorViewModel.CaracteresMinimos)]
        [MaxLength(8, ErrorMessage = ErrorViewModel.CaracteresMaximos)]
        public string Dni { get; set; }
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [MinLength(3, ErrorMessage = ErrorViewModel.CaracteresMinimos)]
        [MaxLength(50, ErrorMessage = ErrorViewModel.CaracteresMaximos)]
        [Display(Name = "Nombre y Apellido")]
        public string nombreCompleto { get; set; }
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [Display(Name = "Email")]
        public string mail { get; set; }
        [Display(Name = "Tipo De Usuario")]
        [EnumDataType(typeof(TipoUsuario))]
        public TipoUsuario tipo { get; set; }
        [Display(Name = "Nombre De Usuario")]
        public string nomUsuario { get; set; }
        public string pass { get; set; }

    }
}
