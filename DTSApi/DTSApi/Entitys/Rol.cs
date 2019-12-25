﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    [Table("ROL", Schema = "DTS_SEGURIDAD")]
    public class Rol
    {

        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }

        public List<RolesEsquema> RolesEsquemas { get; set; }
    }
}