using System;
using System.Collections.Generic;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=blog;User ID=sa;Password=123!@#sql";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);

            Database.Connection.Open();
            Load();
            Console.ReadKey();
            Database.Connection.Close();

        }


        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Vincular perfil/usuário");
            Console.WriteLine("6 - Vincular post/tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                default: Load(); break;

            }

        }
    }
}
