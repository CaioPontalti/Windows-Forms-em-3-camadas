using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace UI
{
    public partial class Form1 : Form
    {
        private ClienteBLL cliBLL;
        private ClienteDTO cliDTO;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            cliBLL = new ClienteBLL();
            cliDTO = new ClienteDTO()
            {
                Nome = txtNome.Text,
                SobreNome = txtSobreNome.Text
            };

            cliBLL.InserirCliente(cliDTO);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cliBLL = new ClienteBLL();
            try
            {
                dgwClientes.DataSource = cliBLL.RetornarClientes();
            }
            catch (Exception ex )
            {
                throw new Exception("Erro ao carregar Grid. " + ex.Message);
            }
        }
    }
}
