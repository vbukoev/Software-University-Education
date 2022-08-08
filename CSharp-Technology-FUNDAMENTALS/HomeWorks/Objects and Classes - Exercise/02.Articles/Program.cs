using System;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {            
            string[] currArt = Console.ReadLine().Split(", ");
            int cntChanges = int.Parse(Console.ReadLine());
            var art = new Article(currArt[0], currArt[1], currArt[2]);
            for (int i = 0; i < cntChanges; i++)
            {
                string[] lines = Console.ReadLine().Split(": ");
                string command = lines[0];
                string argument = lines[1];
                switch (command)
                {
                    case "Edit":
                        art.Edit(argument);
                        break;
                    case "ChangeAuthor":
                        art.ChangeAuthor(argument);
                        break;
                    case "Rename":
                        art.Rename(argument);
                        break;
                }
            }
            Console.WriteLine(art);
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            Author = author;
            Title = title;
            Content = content;
        }
        public string Title { get; set; } //getter - moje da se dostupi propurtito
        public string Content { get; set; }
        public string Author { get; set; }

        public void Rename(string title) => Title = title;
        public void Edit(string content) => Content = content;
        public void ChangeAuthor(string author) => Author = author;
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
