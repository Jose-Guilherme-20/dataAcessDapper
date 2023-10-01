using System.ComponentModel;
using System.Data;
using System.Data.Common;
using Dapper;
using DataAcess.models;
using Microsoft.Data.SqlClient;

namespace DataAcess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = $"Server=localhost,1433;Database=LavaJatos;User ID=sa; Password=Esoj1214-";

            using (var connection = new SqlConnection(connectionString))
            {
                // UpdateLavagem(connection);
                OneToOne(connection);
            }

        }
        static void ListLavagem(SqlConnection connection)
        {
            var sql = "SELECT [id], [nome] FROM lavagem";
            var lavagens = connection.Query<Lavagem>(sql);
            foreach (var item in lavagens)
            {
                System.Console.WriteLine($"{item.id} - {item.nome}");
            }
        }
        static void Createlavagem(SqlConnection connection)
        {
            var lavagem = new Lavagem();
            lavagem.nome = "Lavagem-Media";
            var insertSql = @"INSERT INTO 
            lavagem (nome)
            VALUES(
             @nome)";

            connection.Execute(insertSql, new
            {
                lavagem.nome
            });

        }
        static void UpdateLavagem(SqlConnection connection)
        {
            var updateLavagem = "UPDATE [lavagem] SET [nome]=@nome WHERE id = @id";

            connection.Execute(updateLavagem, new
            {
                id = 2,
                nome = "semi-completa"
            });
        }
        static void CreateManyLavagem(SqlConnection connection)
        {
            var lavagem1 = new Lavagem();
            lavagem1.nome = "lavagem interior";

            var lavagem2 = new Lavagem();
            lavagem2.nome = "Lavagem exterior";
            var sql = @"INSERT INTO 
            lavagem (nome)
            VALUES(
             @nome)";

            connection.Execute(sql, new[]{
                new {
                    lavagem1.nome
                },
                new {
                    lavagem2.nome
                }
             });
        }
        // static void ExecuteProcedure(SqlConnection connection)
        // {
        //     var sql = "[spDeleteLavagem] @StudentId";
        //     var pars = new { IdentifierCase = 2};
        //     connection.Execute(sql, pars, commandType: CommandType.StoredProcedure);
        // } 
        static void OneToOne(SqlConnection connection)
        {
            var sql = @"SELECT
            *
            FROM
            [CLIENTE]
            INNER JOIN
            [VEICULO] ON [CLIENTE].[idVeiculo] = [VEICULO].[id]";
            var items = connection.Query<Cliente, Veiculo, Cliente>(sql, (cliente, veiculo)=>{
                cliente.Veiculo = veiculo;
                return cliente;
            }, splitOn: "id");

            foreach(var item in items)
            {
                System.Console.WriteLine(item.nomeCompleto);
            }

        }
    }

}