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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
                    }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Imprimir_Produto imprimir_Produto = new Imprimir_Produto();
            imprimir_Produto.Show();    
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ConsultaCliente consulta_Cliente = new ConsultaCliente();
            consulta_Cliente.Show();
        }

        private void toolStripButton3_Click_2(object sender, EventArgs e)
        {
            CadastroFornecedor cadastroFornecedor = new CadastroFornecedor();
            cadastroFornecedor.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            consultaFornecedor consulta_Fornecedor = new consultaFornecedor();
            consulta_Fornecedor.Show();
        }
    }
}
