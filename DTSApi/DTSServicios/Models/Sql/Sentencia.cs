namespace DTSServicios.Models.Sql
{
    public class SentenciaSql
    {
        public string Sentencia { get; set; }
        public Parametro[] Parametros { get; set; }
        public bool AutoCompletar { get; set; }
    }
}
