using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace CapaDatos
{
    public class Connection : IBasicconnection, IConnection
    {
        #region Propiedades
        public SqlConnection MyConnection { get; set; }
        public SqlCommand MyCommand { get; set; }
        public string Referente { get; set; }
        public string ConnectionString { get; set; }
        #endregion
        #region ConstructorSingleton

        static Connection instance = new Connection();
        public static Connection GetInstance => instance;
        private Connection()
        {
            string PathConfig = AppDomain.CurrentDomain.BaseDirectory + "web.config";
            if (File.Exists(PathConfig))
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;     
                MyConnection = new SqlConnection(ConnectionString);
                return;
            }
            throw new Exception("ERROR: No se encontro la base de datos");
        }
        #endregion
        #region IBasicConnection
        public void OpenConnection()
        {
            if(MyConnection.State != ConnectionState.Open)
            {
                try
                {
                    MyConnection.Open();
                }
                catch (Exception)
                {
                    throw new Exception("ERROR: No se pudo abrir la conexion");
                }
            }
        }
        #endregion
        #region IConnection
        public void CreateCommand(string storeprocedure, string referente)
        {
            MyCommand = new SqlCommand(storeprocedure, MyConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            Referente = referente;
        }
        public void Delete()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo eliminar el registro");
            }
            finally
            {
                MyConnection.Close();
            }
        }
        public bool Exists()
        {
            OpenConnection();
            try
            {
                int i = int.Parse(MyCommand.ExecuteScalar().ToString());
                return i > 0;
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo encontrar " + Referente);
            }
            finally
            {
                MyConnection.Close();
            }
        }
        public int Insert()
        {
            OpenConnection();
            try
            {
                int i = int.Parse(MyCommand.ExecuteScalar().ToString());
                return i;
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo agregar " + Referente);
            }
            finally
            {
                MyConnection.Close();
            }
        }
        public void InsertWithoutID()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo insertar el registro ");
            }
            finally
            {
                MyConnection.Close();
            }
        }
        public DataTable List()
        {
            OpenConnection();
            try
            {
                DataTable DT = new DataTable();
                DT.Load(MyCommand.ExecuteReader());
                return DT;
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo listar " + Referente);
            }
            finally
            {
                MyConnection.Close();
            }
        }
        public DataRow Find()
        {
            OpenConnection();
            try
            {
                DataTable DT = new DataTable();
                DT.Load(MyCommand.ExecuteReader());
                return DT.Rows[0];
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo encontrar " + Referente);
            }
            finally
            {
                MyConnection.Close();
            }
        }
        public void Update()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo actualizar el registro");
            }
            finally
            {
                MyConnection.Close();
            }
        }
        #endregion

        #region IParameters
        public void ParameterAddBool(string name, bool value)
        {
            MyCommand.Parameters.AddWithValue("@" + name, value);
        }
        public void ParameterAddDateTime(string name, DateTime value)
        {
            MyCommand.Parameters.AddWithValue("@" + name, value);
        }
        public void ParameterAddFloat(string name, double value)
        {
            MyCommand.Parameters.AddWithValue("@" + name, value);
        }   
        public void ParameterAddInt(string name, int value)
        {
            MyCommand.Parameters.AddWithValue("@" + name, value);
        }
        public void ParameterAddVarChar(string name, string value)
        {
            MyCommand.Parameters.AddWithValue("@" + name, value);
        }
        #endregion
    }
}
