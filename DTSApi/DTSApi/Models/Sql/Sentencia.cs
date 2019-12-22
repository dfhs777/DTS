using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Models.Sql
{
    public class SentenciaSql
    {
        public string Sentencia { get; set; }
        public Parametro[] Parametros { get; set; }
        public bool AutoCompletar { get; set; }
    }
}
