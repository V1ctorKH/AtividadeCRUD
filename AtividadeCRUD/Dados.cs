using System;
using System.Data;
using System.Data.SqlClient;

public class Dados
{
	
	private string _connectionString =
	"Data Source=SEU_SERVIDOR_OU_NOME_INSTANCIA;Initial Catalog=FinancasPessoaisDB;Integrated Security=True;";
	// Exemplo: "Data Source=.;Initial Catalog=FinancasDB;Integrated Security=True;";

	public DataTable ObterLancamentos()
	{
		DataTable dt = new DataTable();
		string query = "SELECT Id, Descricao, Valor, DataLancamento, Tipo FROM Lancamentos ORDER BY DataLancamento DESC";

		using (SqlConnection conn = new SqlConnection(_connectionString))
		using (SqlCommand cmd = new SqlCommand(query, conn))
		{
			try
			{
				conn.Open();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				// Em aplicações reais, você deve registrar este erro (log)
				System.Windows.Forms.MessageBox.Show("Erro ao carregar dados: " + ex.Message);
			}
		}
		return dt;
	}

	public void SalvarLancamento(string descricao, decimal valor, DateTime data, string tipo)
	{
		string query = "INSERT INTO Lancamentos (Descricao, Valor, DataLancamento, Tipo) VALUES (@Descricao, @Valor, @Data, @Tipo)";

		using (SqlConnection conn = new SqlConnection(_connectionString))
		using (SqlCommand cmd = new SqlCommand(query, conn))
		{
			cmd.Parameters.AddWithValue("@Descricao", descricao);
			cmd.Parameters.AddWithValue("@Valor", valor);
			cmd.Parameters.AddWithValue("@Data", data.Date); // Apenas a data
			cmd.Parameters.AddWithValue("@Tipo", tipo);

			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Erro ao salvar lançamento: " + ex.Message);
			}
		}
	}

	public void AtualizarLancamento(int id, string descricao, decimal valor, DateTime data, string tipo)
	{
		string query = "UPDATE Lancamentos SET Descricao = @Descricao, Valor = @Valor, DataLancamento = @Data, Tipo = @Tipo WHERE Id = @Id";

		using (SqlConnection conn = new SqlConnection(_connectionString))
		using (SqlCommand cmd = new SqlCommand(query, conn))
		{
			cmd.Parameters.AddWithValue("@Id", id);
			cmd.Parameters.AddWithValue("@Descricao", descricao);
			cmd.Parameters.AddWithValue("@Valor", valor);
			cmd.Parameters.AddWithValue("@Data", data.Date);
			cmd.Parameters.AddWithValue("@Tipo", tipo);

			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Erro ao atualizar lançamento: " + ex.Message);
			}
		}
	}

	public void ExcluirLancamento(int id)
	{
		string query = "DELETE FROM Lancamentos WHERE Id = @Id";

		using (SqlConnection conn = new SqlConnection(_connectionString))
		using (SqlCommand cmd = new SqlCommand(query, conn))
		{
			cmd.Parameters.AddWithValue("@Id", id);

			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Erro ao excluir lançamento: " + ex.Message);
			}
		}
	}
}