﻿using System.Data;

namespace DTSServicios.Models.Sql
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }
        public DbType TipoDato { get; set; }
        public int Longitud { get; set; }
    }
}
