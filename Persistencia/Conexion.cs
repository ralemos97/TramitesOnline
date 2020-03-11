using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Persistencia
{
    internal class Conexion
    {
        private const string DataBaseName = "TramitesOnline";
        private const string Server = @".\SQL2012";
        private SqlConnection cnn = null;

        private readonly string _connectionString;
        
        public string ConnectionString
        {
            get { return _connectionString; }            
        }
        
        public void Conectar()
        {
            if(cnn == null)
            {
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();
            }
            else
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                    cnn = new SqlConnection(ConnectionString);
                }
            }
        }

        public void Desconectar()
        {
            if(cnn != null && cnn.State == System.Data.ConnectionState.Open)
            {
                cnn.Close();
                cnn = null;
            }
        }

        public SqlConnection GetSqlConnection()
        {
            if (cnn == null)
                throw new Exception("No existe conexion generada");

            return cnn;
        }

        public Conexion()
        {
            _connectionString = $"Server={Server};DataBase={DataBaseName};Trusted_Connection=True;";
        }

        public Conexion(Usuario user)
        {
            _connectionString = $"Server={Server};DataBase={DataBaseName};User Id={user.Documento};Password={user.Contrasena};";
        }
    }

    internal class UtilidadesDB
    {
        public SqlParameter ValueReturn = null;
        public SqlCommand Command = null;
        
        public void GenerarValueReturn(SqlCommand cmdToAddParmaeter)
        {
            ValueReturn = new SqlParameter();
            ValueReturn.Direction = System.Data.ParameterDirection.ReturnValue;

            cmdToAddParmaeter.Parameters.Add(ValueReturn);
        }

        public int GetValuerReturn()
        {
            return ValueReturn == null ? 0 : Convert.ToInt32(ValueReturn.Value);
        }

        public SqlCommand GenerarStoreProcedure(string nameStore, SqlConnection cnn)
        {
            if (string.IsNullOrEmpty(nameStore) || cnn == null)
                throw new Exception("Se necesita nombre de SP y conexión.");

            Command = new SqlCommand(nameStore, cnn);
            Command.CommandType = System.Data.CommandType.StoredProcedure;
            return Command;
        }
    }
}
