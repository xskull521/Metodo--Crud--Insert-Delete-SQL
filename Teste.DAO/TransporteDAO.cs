using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Teste.Entidades;

namespace Teste.DAO
{
    public class TransporteDAO
    {
        public List<Transporte> SelectAllTransporte()
        {
            string connectionString =
            @"Data Source=MTZNOTFS033786\SQLEXPRESS;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * FROM Transporte";

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
                    var _Transporte = new List<Transporte>();

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _Transporte.Add(new Transporte()
                        {
                            Ano = Convert.ToInt32(reader["Ano"]),
                            Tipo_Veiculo = reader["Tipo_Veiculo"].ToString()

                        });
                    }
                    reader.Close();
                    return _Transporte;
                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
        }

        public void InsertDataTransporte(string Tipo_Veiculo,  int Ano)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "INSERT INTO dbo.Transporte (Tipo_Veiculo, Ano) " +
                   "VALUES (@Tipo_Veiculo, @Ano) ";



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

                    cmd.Parameters.Add("@Rua", SqlDbType.VarChar, 50).Value = Tipo_Veiculo;
                    cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = Ano;


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

                    string query = "DELETE FROM Transporte WHERE IdTransporte=@Id";
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



    }
}
