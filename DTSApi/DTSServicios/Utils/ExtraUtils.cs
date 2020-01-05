using DTSServicios.Models.Sql;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DTSServicios.Utils
{
    public class ExtraUtils
    {
        public static List<Npgsql.NpgsqlParameter> ConvertirAParamPostgres(List<Parametro> parametros)
        {
            List<Npgsql.NpgsqlParameter> listaParametros = new List<Npgsql.NpgsqlParameter>();


            foreach (var item in parametros)
            {
                // Porque lo convierte en System.Text.Json.JsonElement
                string json = System.Text.Json.JsonSerializer.Serialize(item.Valor);
                object value = JsonConvert.DeserializeObject(json);

                Npgsql.NpgsqlParameter parametro = new Npgsql.NpgsqlParameter(item.Nombre, value);
                parametro.DbType = item.TipoDato;
                listaParametros.Add(parametro);
            }

            return listaParametros;
        }

        public static SentenciaSql GenerarSqlSelect(Type tipo, SentenciaSql sentencia, DatabaseContext context)
        {
            if (sentencia.AutoCompletar && sentencia != null)
            {
                StringBuilder sentenciaCompleta = new StringBuilder();
                var mapping = context.Model.FindEntityType(tipo);
                sentenciaCompleta.Append("SELECT \"");
                sentenciaCompleta.Append(mapping.GetSchema());
                sentenciaCompleta.Append("\".\"");
                sentenciaCompleta.Append(mapping.GetTableName());
                sentenciaCompleta.Append("\".*");
                sentenciaCompleta.Append(" FROM \"");
                sentenciaCompleta.Append(mapping.GetSchema());
                sentenciaCompleta.Append("\".\"");
                sentenciaCompleta.Append(mapping.GetTableName());
                sentenciaCompleta.Append("\" ");
                sentenciaCompleta.Append(sentencia.Sentencia);

                sentencia.Sentencia = sentenciaCompleta.ToString();
            }
            return sentencia;
        }

        public static List<SqlParameter> ConvertirAParamSqlServer(List<Parametro> parametros)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            foreach (var item in parametros)
            {
                listaParametros.Add(new SqlParameter() { ParameterName = item.Nombre, DbType = item.TipoDato, Size = item.Longitud, Value = item.Valor });
            }
            return listaParametros;
        }
    }
}
