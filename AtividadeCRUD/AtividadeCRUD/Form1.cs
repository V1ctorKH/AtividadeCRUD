using System;
using System.Data;
using System.Windows.Forms;

public partial class Form1 : Form
{
	private Dados dados = new Dados();
	private int idLancamentoSelecionado = 0; // Armazena o Id para Atualização/Exclusão

	public Form1()
	{
		InitializeComponent();
		CarregarLancamentos();
		ConfigurarDataGridView();
		cmbTipo.Items.Add("Credito");
		cmbTipo.Items.Add("Debito");
		cmbTipo.SelectedIndex = 0;
	}

	// --- Métodos de Carregamento e Configuração ---

	private void ConfigurarDataGridView()
	{
		dgvLancamentos.AutoGenerateColumns = true;
		dgvLancamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgvLancamentos.MultiSelect = false;

		// Ocultar a coluna Id para o usuário, mas manter para o código
		dgvLancamentos.Columns["Id"].Visible = false;

		// Renomear colunas para exibição
		dgvLancamentos.Columns["Descricao"].HeaderText = "Descrição";
		dgvLancamentos.Columns["DataLancamento"].HeaderText = "Data";
		dgvLancamentos.Columns["Valor"].HeaderText = "Valor (R$)";
		dgvLancamentos.Columns["Tipo"].HeaderText = "Tipo";
	}

	private void CarregarLancamentos()
	{
		try
		{
			dgvLancamentos.DataSource = dados.ObterLancamentos();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Falha ao carregar a lista de lançamentos: " + ex.Message);
		}
	}

	private void LimparCampos()
	{
		txtDescricao.Clear();
		txtValor.Clear();
		dtpDataLancamento.Value = DateTime.Today;
		cmbTipo.SelectedIndex = 0; // Define o primeiro item ('Credito') como padrão

		idLancamentoSelecionado = 0;
		btnSalvar.Text = "Salvar Novo";
		btnExcluir.Enabled = false;
	}

	// --- Eventos de Botão (CRUD) ---

	private void btnSalvar_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(txtDescricao.Text) || string.IsNullOrWhiteSpace(txtValor.Text) || cmbTipo.SelectedItem == null)
		{
			MessageBox.Show("Preencha todos os campos e selecione o tipo (Crédito/Débito).");
			return;
		}

		if (!decimal.TryParse(txtValor.Text, out decimal valor))
		{
			MessageBox.Show("Valor inválido. Use um formato numérico.");
			return;
		}

		// PEGA O TIPO DIRETAMENTE DO COMBOBOX
		string tipo = cmbTipo.SelectedItem.ToString();

		if (idLancamentoSelecionado == 0)
		{
			// C - Create (Salvar Novo)
			dados.SalvarLancamento(txtDescricao.Text, valor, dtpDataLancamento.Value, tipo);
			MessageBox.Show("Lançamento salvo com sucesso!");
		}
		else
		{
			// U - Update (Atualizar)
			dados.AtualizarLancamento(idLancamentoSelecionado, txtDescricao.Text, valor, dtpDataLancamento.Value, tipo);
			MessageBox.Show("Lançamento atualizado com sucesso!");
		}

		CarregarLancamentos();
		LimparCampos();
	}

	private void btnExcluir_Click(object sender, EventArgs e)
	{
		if (idLancamentoSelecionado > 0)
		{
			// D - Delete
			var resultado = MessageBox.Show($"Tem certeza que deseja excluir o lançamento ID: {idLancamentoSelecionado}?", "Confirmação", MessageBoxButtons.YesNo);
			if (resultado == DialogResult.Yes)
			{
				dados.ExcluirLancamento(idLancamentoSelecionado);
				MessageBox.Show("Lançamento excluído com sucesso!");
				CarregarLancamentos();
				LimparCampos();
			}
		}
	}

	private void btnLimpar_Click(object sender, EventArgs e)
	{
		LimparCampos();
	}

	// --- Evento de Seleção no DataGridView ---

	private void dgvLancamentos_SelectionChanged(object sender, EventArgs e)
	{
		if (dgvLancamentos.SelectedRows.Count > 0)
		{
			DataGridViewRow linha = dgvLancamentos.SelectedRows[0];

			idLancamentoSelecionado = Convert.ToInt32(linha.Cells["Id"].Value);

			txtDescricao.Text = linha.Cells["Descricao"].Value.ToString();
			txtValor.Text = linha.Cells["Valor"].Value.ToString();
			dtpDataLancamento.Value = Convert.ToDateTime(linha.Cells["DataLancamento"].Value);

			// PREENCHE O COMBOBOX COM O VALOR DA LINHA SELECIONADA
			string tipo = linha.Cells["Tipo"].Value.ToString();
			cmbTipo.Text = tipo; // Define o texto do ComboBox

			btnSalvar.Text = "Atualizar";
			btnExcluir.Enabled = true;
		}
	}
}