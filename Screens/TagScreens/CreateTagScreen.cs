using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Tag");
            Console.WriteLine("----------------");
            Console.WriteLine("Qual será o nome da Tag?");
            var name = Console.ReadLine();

            Console.WriteLine("Qual será o Slug da Tag?");
            var slug = Console.ReadLine();

            Create(new Tag
            {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuTagScreen.Load();


        }

        private static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag criada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Não foi possível criar a tag");
            }
        }
    }
}