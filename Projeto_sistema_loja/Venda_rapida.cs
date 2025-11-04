using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Projeto_sistema_loja
{
    public partial class Venda_rapida : Form
    {
        public Venda_rapida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = textBoxCodigo.Text;
            string descricao = textBoxDescricao.Text;
            int quantidade = int.Parse(textBoxQuantidade.Text);
            double precoCusto = double.Parse(textBoxCusto.Text);
            double precoVenda = double.Parse(textBoxVenda.Text);
            string marca = textBoxMarca.Text;
            string sabor = textBoxSabor.Text;
            string validade = textBoxValidade.Text;

            string conexaoBanco = "server=localhost;user=root;password=;database=db_sistema_loja";
            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco))
            {
                try
                {
                    conexao.Open();
                    string query = "INSERT INTO tb_produto ( codigo_barra, descricao,quantidade, valor_unidade, preco_venda, validade, marca, sabor) VALUES ( @codigo_barra, @descricao,@quantidade, @valor_unidade, @preco_venda, @validade, @marca, @sabor)";


                    MySqlCommand comando = new MySqlCommand(query, conexao);
                    comando.Parameters.AddWithValue("@codigo_barra", codigo);
                    comando.Parameters.AddWithValue("@descricao", descricao);
                    comando.Parameters.AddWithValue("quantidade", quantidade);
                    comando.Parameters.AddWithValue("@valor_unidade", precoCusto);
                    comando.Parameters.AddWithValue("@preco_venda", precoVenda);
                    comando.Parameters.AddWithValue("@validade", validade);
                    comando.Parameters.AddWithValue("@marca", marca);

                    comando.Parameters.AddWithValue("@sabor", sabor);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Produto salvo com sucesso!");
                    conexao.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar cliente: erro na conexao com o banco" + ex.Message);
                }


            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Arquivos de imagem (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            dialog.Title = "Selecione uma imagem";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string origem = dialog.FileName;
                string nomeArquivo = Path.GetFileName(origem);
                string pastaDestino = Path.Combine(Application.StartupPath, "imagens");

                // Cria a pasta se não existir
                if (!Directory.Exists(pastaDestino))
                    Directory.CreateDirectory(pastaDestino);

                string destino = Path.Combine(pastaDestino, nomeArquivo);

                // Copia o arquivo para a pasta local
                File.Copy(origem, destino, true);

                // Exibe a imagem no PictureBox
                pictureBox1.Image = Image.FromFile(destino);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                // Salva no banco
                SalvarImagemNoBanco(destino, nomeArquivo);

            }

        }
            


        private void SalvarImagemNoBanco(string localizacao, string nomeArquivo)
        {
            string conexaoBanco = "server=localhost;user=root;password=;database=db_sistema_loja";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexaoBanco))
                {
                    conn.Open();

                    string sql = "INSERT INTO tb_imagem (localizacao, nome_arquivo) VALUES (@localizacao, @nome)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@localizacao", localizacao);
                    cmd.Parameters.AddWithValue("@nome", nomeArquivo);

                    cmd.ExecuteNonQuery();
              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar imagem: " + ex.Message);
            }
        }




        }
}
