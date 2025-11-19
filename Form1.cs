using System;
using System.Windows.Forms;
using System.Data;

namespace AtividadeCRUD
{
    public partial class Form1 : Form
    {
        private TransacaoDAO dao = new TransacaoDAO();
        private int idSelecionado = 0;

        public Form1()
        {
            InitializeComponent();
            CarregarDados();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Configuração da ComboBox 'cmbModalidade'
            cmbModalidade.Items.Add("Credito");
            cmbModalidade.Items.Add("Debito");
            cmbModalidade.DropDownStyle = ComboBoxStyle.DropDownList; // Impede que o usuário digite
            cmbModalidade.SelectedIndex = -1; // Começa sem seleção

            // Configuração inicial do DataGridView (Opcional)
            Lançamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Lançamentos.MultiSelect = false;
        }

        private void CarregarDados()
        {
            try
            {
                Lançamentos.DataSource = dao.ObterTodasTransacoes();

                // O ID será visível AGORA, pois a instrução para escondê-lo foi removida.

                // Formatação da coluna Valor (Opcional, mas melhora a visualização)
                if (Lançamentos.Columns.Contains("Valor"))
                {
                    // C2 = Moeda com 2 decimais
                    Lançamentos.Columns["Valor"].DefaultCellStyle.Format = "C2";
                }

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDesc.Text) || string.IsNullOrWhiteSpace(txtValor.Text) || cmbModalidade.SelectedIndex == -1)
                {
                    MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descricao = txtDesc.Text;
                DateTime data = dateTimePicker1.Value;
                decimal valor = Convert.ToDecimal(txtValor.Text);
                string tipo = cmbModalidade.SelectedItem.ToString();

                dao.InserirTransacao(descricao, data, valor, tipo);
                MessageBox.Show("Transação registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();

            }
            catch (FormatException)
            {
                MessageBox.Show("O valor precisa ser um número válido.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lançamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Lançamentos.Rows[e.RowIndex];

                idSelecionado = Convert.ToInt32(row.Cells["ID"].Value);

                txtDesc.Text = row.Cells["Descricao"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["DataTransacao"].Value);
                txtValor.Text = row.Cells["Valor"].Value.ToString();
                cmbModalidade.SelectedItem = row.Cells["Tipo"].Value.ToString();
            }
        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            if (idSelecionado == 0)
            {
                MessageBox.Show("Selecione uma transação na lista para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string descricao = txtDesc.Text;
                DateTime data = dateTimePicker1.Value;
                decimal valor = Convert.ToDecimal(txtValor.Text);
                string tipo = cmbModalidade.SelectedItem.ToString();

                dao.AtualizarTransacao(idSelecionado, descricao, data, valor, tipo);
                MessageBox.Show("Transação atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            if (idSelecionado == 0)
            {
                MessageBox.Show("Selecione uma transação na lista para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Tem certeza que deseja excluir esta transação?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dao.ExcluirTransacao(idSelecionado);
                    MessageBox.Show("Transação excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CarregarDados();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparCampos()
        {
            txtDesc.Clear();
            txtValor.Clear();
            cmbModalidade.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            idSelecionado = 0;
        }

        private void bntConsultar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void txtValor_TextChanged(object sender, EventArgs e) { }
        private void cmbModalidade_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtConsulta_TextChanged(object sender, EventArgs e) { }
        private void txtSaldo_TextChanged(object sender, EventArgs e) { }
    }
}