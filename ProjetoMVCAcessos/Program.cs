using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Acesso_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Cadastro cadastro = new Cadastro();
            Console.WriteLine("Bem-vindo ao Sistema de Controle de Acessos.");
            int opcao;

            do
            {
                
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar ambiente");
                Console.WriteLine("2. Consultar ambiente");
                Console.WriteLine("3. Excluir ambiente");
                Console.WriteLine("4. Cadastrar usuário");
                Console.WriteLine("5. Consultar usuário");
                Console.WriteLine("6. Excluir usuário");
                Console.WriteLine("7. Conceder permissão de acesso");
                Console.WriteLine("8. Revogar permissão de acesso");
                Console.WriteLine("9. Registrar acesso");
                Console.WriteLine("10. Consultar logs de acesso");
                Console.Write("\nSelecione uma opção:");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Encerrando aplicação...");
                        break;
                    case 1:
                        CadastrarAmbiente(cadastro);
                        break;
                    case 2:
                        ConsultarAmbiente();
                        break;
                    case 3:
                        ExcluirAmbiente();
                        break;
                    case 4:
                        CadastrarUsuario(cadastro);
                        break;
                    case 5:
                        ConsultarUsuario();
                        break;
                    case 6:
                        ExcluirUsuario();
                        break;
                    case 7:
                        ConcederPermissao();
                        break;
                    case 8:
                        RevogarPermissao();
                        break;
                    case 9:
                        RegistrarAcesso();
                        break;
                    case 10:
                        ConsultarLogs();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 0);
        }

        // Método para Cadastrar Ambiente
        
        static void CadastrarAmbiente(Cadastro cadastro)
        {
            Console.Write("Informe o ID do ambiente: ");
            int idAmbiente = int.Parse(Console.ReadLine());
            Console.Write("Informe o nome do ambiente: ");
            string nomeAmbiente = Console.ReadLine();

            // Query para inserir o ambiente no banco de dados
            string query = "INSERT INTO ambientes (id, nome) VALUES (@idAmbiente, @nomeAmbiente);";

            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros da query
                        cmd.Parameters.AddWithValue("@idAmbiente", idAmbiente);
                        cmd.Parameters.AddWithValue("@nomeAmbiente", nomeAmbiente);

                        // Executa a query
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Ambiente cadastrado com sucesso.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar ambiente: " + ex.Message);
                }
            }
        }



        // Método para Consultar Ambiente
        static void ConsultarAmbiente()
        {
            string query = "SELECT * FROM ambientes;";

            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Nenhum ambiente encontrado.");
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao consultar ambientes: " + ex.Message);
                }
            }
        }


        // Método para Excluir Ambiente
        static void ExcluirAmbiente()
        {
            Console.Write("Informe o ID do ambiente a ser excluído: ");
            int idAmbiente = int.Parse(Console.ReadLine());
            string query = "DELETE FROM ambientes WHERE id = @id;";
            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idAmbiente);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Ambiente excluído com sucesso.");
        }

        
        // Método para Cadastrar Usuário
        static void CadastrarUsuario(Cadastro cadastro)
        {
            Console.Write("Informe o ID do usuário: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("Informe o nome do usuário: ");
            string nomeUsuario = Console.ReadLine();

            // Query para inserir o usuário no banco de dados
            string query = "INSERT INTO usuarios (id, nome) VALUES (@idUsuario, @nomeUsuario);";

            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros da query
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);

                        // Executa a query
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Usuário cadastrado com sucesso.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar usuário: " + ex.Message);
                }
            }
        }


        // Método para Consultar Usuário
        static void ConsultarUsuario()
        {
            string query = "SELECT * FROM usuarios;";

            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Nenhum usuário encontrado.");
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao consultar usuários: " + ex.Message);
                }
            }
        }


        // Método para Excluir Usuário
        static void ExcluirUsuario()
        {
            Console.Write("Informe o ID do usuário a ser excluído: ");
            int idUsuario = int.Parse(Console.ReadLine());
            string query = "DELETE FROM usuarios WHERE id = @id;";
            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Usuário excluído com sucesso.");
       
        }

        // Método para conceder permissão de acesso
        static void ConcederPermissao()
        {
            Console.Write("Informe o ID do usuário: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("Informe o ID do ambiente: ");
            int idAmbiente = int.Parse(Console.ReadLine());

            string query = "INSERT INTO permissoes (usuario_id, ambiente_id) VALUES (@idUsuario, @idAmbiente);";

            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idAmbiente", idAmbiente);

                    // Executa a query no banco de dados
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Permissão concedida com sucesso.");
        }


        // Método para revogar permissão de acesso
        static void RevogarPermissao()
        {
            Console.Write("Informe o ID do usuário: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("Informe o ID do ambiente: ");
            int idAmbiente = int.Parse(Console.ReadLine());

            string query = "DELETE FROM permissoes WHERE usuario_id = @idUsuario AND ambiente_id = @idAmbiente;";

            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idAmbiente", idAmbiente);

                    // Executa a query no banco de dados
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Permissão revogada com sucesso.");
        }


        // Método para registrar o acesso de um usuário
        // Método para registrar o acesso de um usuário
        static void RegistrarAcesso()
        {
            Console.Write("Informe o ID do usuário: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("Informe o ID do ambiente acessado: ");
            int idAmbiente = int.Parse(Console.ReadLine());

            // Aqui vamos registrar a data/hora do acesso
            DateTime dataAcesso = DateTime.Now;

            string query = "INSERT INTO logs_acesso (usuario_id, ambiente_id, data_acesso) VALUES (@idUsuario, @idAmbiente, @dataAcesso);";

            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idAmbiente", idAmbiente);
                    cmd.Parameters.AddWithValue("@dataAcesso", dataAcesso);

                    // Executa a query no banco de dados
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Acesso registrado com sucesso.");
        }


        // Método para consultar logs de acesso
        static void ConsultarLogs()
        {
            string query = "SELECT * FROM logs_acesso;";

            using (var conn = new MySqlConnection("Server=localhost;Database=Acessos;Uid=root;Pwd=*Consagrado712;"))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Nenhum log de acesso encontrado.");
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    DateTime dataAcesso = Convert.ToDateTime(reader["data_acesso"]);
                                    Console.WriteLine($"ID Usuário: {reader["usuario_id"]}, ID Ambiente: {reader["ambiente_id"]}, Data/Hora: {dataAcesso}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao consultar logs de acesso: " + ex.Message);
                }
            }
        
        }

    }
}