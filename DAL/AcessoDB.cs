using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class AcessoDB
    {
        private SqlConnection _sqlConn;
        private SqlCommand _sqlComm;
        private DataTable _dt;
        private SqlDataAdapter _da;
        private SqlParameterCollection _sqlParam;

        public void Conectar()
        {
            _sqlConn = new SqlConnection();
            _sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
            _sqlConn.Open();
        }

        public void FecharConexao()
        {
            _sqlConn.Close();
            _sqlConn.Dispose();
        }

        public void ExecutarComando(CommandType commandType, string SQL)
        {
            try
            {
                _sqlComm = new SqlCommand();
                _sqlComm.Connection = _sqlConn;
                _sqlComm.CommandType = commandType;
                _sqlComm.CommandText = SQL;
                foreach (SqlParameter item in _sqlParam)
                {
                    _sqlComm.Parameters.Add(new SqlParameter(item.ParameterName, item.Value)).Direction = item.Direction;
                }
                _sqlComm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Ocorreu um erro ao executar o comando SQL. Erro: " + ex.Message);
            }
        }

        public void AdicionarParametrosProc(string nomeParametro, string valorParametro, ParameterDirection direcao)
        {
            if (_sqlParam == null)
            {
                _sqlParam = new SqlCommand().Parameters;
            }
            _sqlParam.Add(new SqlParameter(nomeParametro, valorParametro)).Direction = direcao;
        }

        public void LimpraParametros()
        {
            _sqlParam.Clear();
        }

        public DataTable RetornarDataTable(CommandType commandType, string SQL)
        {
            try
            {
                _sqlComm = new SqlCommand();
                _sqlComm.Connection = _sqlConn;
                _sqlComm.CommandType = commandType;
                _sqlComm.CommandText = SQL;
                _dt = new DataTable();

                _da = new SqlDataAdapter(_sqlComm);
                _da.Fill(_dt);
                return _dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao retornar o DataTableClientes. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro generico ao retornar o DataTableClientes. Erro: " + ex.Message);
            }
        }
    }
}
