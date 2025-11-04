using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_sistema_loja
{
    public partial class consultaFornecedor : Form
    {
        public consultaFornecedor()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CadastroFornecedor cadastro_Fornecedor = new CadastroFornecedor();
            cadastro_Fornecedor.Show();
        }
    }
}
