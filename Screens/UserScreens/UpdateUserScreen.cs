using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando Usuário");
            Console.WriteLine("----------------");
            Console.WriteLine("Qual Id do usuário que vai alterar?");
            var id = Console.ReadLine();
            Console.WriteLine("Qual será o novo nome do usuário?");
            var name = Console.ReadLine();

            Console.WriteLine("Qual será o novo email do usuário?");
            var email = Console.ReadLine();

            Console.WriteLine("Qual será a nova senha do usuário?");
            var password = Console.ReadLine();

            Console.WriteLine("Qual será a nova bio do usuário?");
            var bio = Console.ReadLine();

            Console.WriteLine("Qual será o novo link de imagem do usuário?");
            var image = Console.ReadLine();

            Console.WriteLine("Qual será o novo Slug do usuário?");
            var slug = Console.ReadLine();

            Update(new User
            {
                Id = int.Parse(id),
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

        private static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Não foi possível atualizar o usuário");
            }
        }
    }
}