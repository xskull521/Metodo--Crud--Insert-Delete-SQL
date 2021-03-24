using System;
using System.Collections.Generic;
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
            @"Data Source=MTZNOTFS033786\SQLEXPRESS;Initial Catalog=Teste;"
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
    }
}
