using MySql.Data.MySqlClient;
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
    public partial class CadastroFornecedor : Form
    {
        public CadastroFornecedor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Por favor, preencha o nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
                textBoxNome.Focus();
              
                return;
            }


            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Por favor, preencha o email.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            
            if (!textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("O email deve conter '@'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }
       

            string nome = textBoxNome.Text;
            string cnpj = textBoxCnpj.Text;
            int telefone = int.Parse(textBoxTelefone.Text);
            string email = textBoxEmail.Text;

            string conexaoBanco = "server=localhost;user=root;password=;database=db_sistema_loja";
            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco))
            {
                try
                {
                    conexao.Open();
                    string query = "INSERT INTO tb_fornecedor (nome, cnpj, telefone, email) VALUES (@nome, @cnpj, @telefone, @email)";


                    MySqlCommand comando = new MySqlCommand(query, conexao);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cnpj", cnpj);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@email", email);


                    comando.ExecuteNonQuery();
                    MessageBox.Show("Fornecedor salvo com sucesso!");




                    textBoxNome.Clear();
                    textBoxCnpj.Clear();
                    textBoxTelefone.Clear();
                    textBoxEmail.Clear();
                ;
             
          
                    conexao.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar cliente: erro na conexao com o banco" + ex.Message);
                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
