using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Usuário");
            Console.WriteLine("-----------------");
            Console.WriteLine("Qual será o nome do usuário?");
            var name = Console.ReadLine();

            Console.WriteLine("Qual será o email do usuário?");
            var email = Console.ReadLine();

            Console.WriteLine("Qual será a password?");
            var password = Console.ReadLine();

            Console.WriteLine("Qual será a Bio?");
            var bio = Console.ReadLine();

            Console.WriteLine("Insira o link da imagem");
            var image = Console.ReadLine();

            Console.WriteLine("Qual será o slug do usuário?");
            var slug = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Image = image,
                Slug = slug
            });

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usuário criado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Não foi possível criar o usuário");
            }

        }
    }
}