using System;
using System.Collections.Generic;
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
    }
}
