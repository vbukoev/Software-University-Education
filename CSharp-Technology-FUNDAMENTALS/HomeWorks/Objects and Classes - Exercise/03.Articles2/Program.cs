using System;
using System.Collections.Generic;

namespace _03.Articles2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cntOfArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < cntOfArticles; i++)
            {
                string[] currArt = Console.ReadLine().Split(", ");
                var art = new Article(currArt[0], currArt[1], currArt[2]);
                articles.Add(art);
            }
            string line = Console.ReadLine();
            foreach (var article in articles) Console.WriteLine(article);    
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
