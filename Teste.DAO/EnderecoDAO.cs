using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Teste.Entidades;

namespace Teste.DAO
{
    public class EnderecoDAO
    {
        public List<Endereco> SelectAllEndereco()
        {
            string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * FROM Endereco";

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
                    var _Endereco = new List<Endereco>();

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _Endereco.Add(new Endereco()
                        {
                            Numero = Convert.ToInt32(reader["Numero"]),
                            Rua = reader["Rua"].ToString(),
                            Complemento = reader["Complemento"].ToString()

                        });
                    }
                    reader.Close();
                    return _Endereco;
                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
        }

        public void InsertData(string Rua, int Numero, string Complemento)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "INSERT INTO dbo.Endereco (Rua, Numero, Complemento) " +
                   "VALUES (@Rua, @Numero, @Complemento) ";



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

                    cmd.Parameters.Add("@Rua", SqlDbType.VarChar, 50).Value = Rua;
                    cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = Numero;
                    cmd.Parameters.Add("@Complemento", SqlDbType.VarChar, 50).Value = Complemento;

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


        public void DeleteData(int Id)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";


            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {


                try
                {

                    string query = "DELETE FROM Endereco WHERE IdEndereco=@Id";
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


        public void UpdateData(Endereco endereco)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "UPDATE Endereco SET Rua = @Rua, Numero = @Numero, Complemento = @Complemento WHERE IdEndereco = @Id";



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
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = endereco.IdEndereco;
                    cmd.Parameters.Add("@Rua", SqlDbType.VarChar, 50).Value = endereco.Rua;
                    cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = endereco.Numero;
                    cmd.Parameters.Add("@Complemento", SqlDbType.VarChar, 50).Value = endereco.Complemento;

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




