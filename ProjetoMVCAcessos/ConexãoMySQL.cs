using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Acesso_C_
{
    internal class ConexãoMySQL
    {
        private string connectionString = "Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;";

        // Método para testar a conexão
        public void TestConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexão bem-sucedida com o MySQL!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao conectar: {ex.Message}");
                }
            }

        }
    }
}