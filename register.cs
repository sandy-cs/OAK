using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CadastroDeProdutos
{
    public partial class MainForm : Form
    {
        private List<Produto> produtos = new List<Produto>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AtualizarListagem();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;
            decimal valor = numericValor.Value;
            bool disponivel = radioSim.Checked;

            Produto produto = new Produto(nome, descricao, valor, disponivel);
            produtos.Add(produto);

            LimparCampos();
            AtualizarListagem();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            numericValor.Value = 0;
            radioSim.Checked = true;
        }

        private void AtualizarListagem()
        {
            var produtosOrdenados = produtos.OrderBy(p => p.Valor).ToList();
            listViewProdutos.Items.Clear();

            foreach (var produto in produtosOrdenados)
            {
                ListViewItem item = new ListViewItem(produto.Nome);
                item.SubItems.Add(produto.Valor.ToString("C"));
                listViewProdutos.Items.Add(item);
            }
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }

        public Produto(string nome, string descricao, decimal valor, bool disponivel)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Disponivel = disponivel;
        }
    }
}
