using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teste.Entidades;

namespace Teste.DAO
{
    public class CadastroTesteDAO
    {
        public List<CadastroTeste> SelectAllClients()
        {
            string connectionString =
            @"Data Source=MTZNOTFS033786\SQLEXPRESS;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * FROM CadastroTeste";

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
                    var _Cadastro = new List<CadastroTeste>();

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _Cadastro.Add(new CadastroTeste()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descricao = reader["Descricao"].ToString()

                        });
                    }
                    reader.Close();
                    return _Cadastro;
                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
        }
    }
}
