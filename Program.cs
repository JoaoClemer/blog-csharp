using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=blog;User ID=sa;Password=123!@#sql";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);

            connection.Open();
            //ReadUsers(connection);
            //ReadUserById(connection, 1);
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.GetAll();
            foreach (var user in users)
                Console.WriteLine(user.Name);
        }

        public static void ReadUserById(SqlConnection connection, int id)
        {
            var repository = new Repository<User>(connection);
            var user = repository.GetId(id);
            Console.WriteLine($"Nome: {user.Name}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Biografia: {user.Bio}");
        }

        public static void CreateUser(SqlConnection connection, User user)
        {
            var repository = new Repository<User>(connection);
            repository.Create(user);
            Console.WriteLine("Usuário criado com sucesso!");
        }

        public static void UpdateUser(SqlConnection connection, User user)
        {
            var repository = new Repository<User>(connection);
            repository.Update(user);
            Console.WriteLine("Dados atualizados com sucesso!");

        }

        public static void DeleteUser(SqlConnection connection, User user, int id)
        {
            var repository = new Repository<User>(connection);
            repository.Delete(id);
            //repository.Delete(user);
            Console.WriteLine("Usuário deletado som sucesso!");
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.GetAll();
            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }


    }
}
