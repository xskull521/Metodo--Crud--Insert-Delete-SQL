using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Teste.Entidades;

namespace Teste.DAO
{
    public class PessoaDAO
    {
        public List<Pessoa> SelectAllPessoa()
        {
            string connectionString =
            @"Data Source=MTZNOTFS033786\SQLEXPRESS;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * FROM Pessoa";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);


                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    var _Pessoa = new List<Pessoa>();

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _Pessoa.Add(new Pessoa()
                        {
                            Idade = Convert.ToInt32(reader["Idade"]),
                            Nome = reader["Nome"].ToString(),

                        });
                    }
                    reader.Close();
                    return _Pessoa;
                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
        }

        public void InsertDataPessoa(string Nome, int Idade)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "INSERT INTO dbo.Pessoas (Nome, Idade) " +
                   "VALUES (@Nome, @Idade)";



            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {


                // Create the Command and Parameter objects.
                SqlCommand cmd = new SqlCommand(queryString, connection);



                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {

                    cmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = Nome;
                    cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = Idade;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();


                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
        }

        public void DeleteDataPessoa(int Id)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";


            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {


                try
                {

                    string query = "DELETE FROM Pessoas WHERE IdPessoa=@Id";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }



                catch (Exception ex)
                {
                    throw ex;

                }


            }
        }

        public void UpdateDataPessoa(Pessoa pessoa)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "UPDATE Pessoa SET Nome = @Nome, Idade = @Idade WHERE IdPessoa = @Id";



            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {


                // Create the Command and Parameter objects.
                SqlCommand cmd = new SqlCommand(queryString, connection);



                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = pessoa.IdPessoa;
                    cmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = pessoa.Nome;
                    cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = pessoa.Idade;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();


                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
        }

    }
}
