using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace AtividadeCRUD
{
    public class TransacaoDAO
    {
        private readonly string connectionString =
            "Data Source=LAB555;Initial Catalog=projetopbd;Integrated Security=True;TrustServerCertificate = true";

        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public void InserirTransacao(string descricao, DateTime data, decimal valor, string tipo)
        {
            string sql = "INSERT INTO Transacoes (Descricao, DataTransacao, Valor, Tipo) " +
                         "VALUES (@Descricao, @Data, @Valor, @Tipo)";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@Descricao", descricao);
                    cmd.Parameters.AddWithValue("@Data", data);
                    cmd.Parameters.AddWithValue("@Valor", valor);
                    cmd.Parameters.AddWithValue("@Tipo", tipo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObterTodasTransacoes()
        {
            string sql = "SELECT ID, Descricao, DataTransacao, Valor, Tipo FROM Transacoes ORDER BY DataTransacao DESC";
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public void AtualizarTransacao(int id, string descricao, DateTime data, decimal valor, string tipo)
        {
            string sql = "UPDATE Transacoes SET Descricao = @Descricao, DataTransacao = @Data, " +
                         "Valor = @Valor, Tipo = @Tipo WHERE ID = @ID";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Descricao", descricao);
                    cmd.Parameters.AddWithValue("@Data", data);
                    cmd.Parameters.AddWithValue("@Valor", valor);
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirTransacao(int id)
        {
            string sql = "DELETE FROM Transacoes WHERE ID = @ID";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}