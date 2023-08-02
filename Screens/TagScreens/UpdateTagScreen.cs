using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando Tag");
            Console.WriteLine("----------------");
            Console.WriteLine("Qual Id da Tag que vai alterar?");
            var id = Console.ReadLine();
            Console.WriteLine("Qual será o novo nome da Tag?");
            var name = Console.ReadLine();

            Console.WriteLine("Qual será o novo Slug da Tag?");
            var slug = Console.ReadLine();

            Update(new Tag
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Não foi possível atualizar a tag");
            }
        }
    }
}