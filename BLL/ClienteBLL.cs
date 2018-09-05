using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BLL
{
    public class ClienteBLL
    {
        private AcessoDB bd;
        private DataTable dtClientes;

        public void InserirCliente(ClienteDTO cliDTO)
        {
            try
            {
                bd = new AcessoDB();
                bd.Conectar();
                bd.AdicionarParametrosProc("@Nome", cliDTO.Nome, ParameterDirection.Input);
                bd.AdicionarParametrosProc("@SobreNome", cliDTO.SobreNome, ParameterDirection.Input);
                bd.ExecutarComando(CommandType.StoredProcedure, "sp_InserirCliente");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao Inserir o cliente. Erro: " + ex.Message);
            }
            finally
            {
                bd.LimpraParametros();
                bd.FecharConexao();
            }
        }

        public DataTable RetornarClientes()
        {
            try
            {
                bd = new AcessoDB();
                bd.Conectar();

                dtClientes = new DataTable();

                return dtClientes = bd.RetornarDataTable(CommandType.StoredProcedure, "sp_RetonarCliente");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao Retornar os Clientes. " + e.Message);
            }
        }
    }
}
