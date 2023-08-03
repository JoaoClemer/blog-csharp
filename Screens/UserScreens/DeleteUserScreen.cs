using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Usuário?");
            Console.WriteLine("----------------");
            Console.WriteLine("Qual Id do usuário que deseja excluir?");
            var id = Console.ReadLine();

            Delete(int.Parse(id));

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Não foi possível excluir o usuário");
            }
        }
    }
}