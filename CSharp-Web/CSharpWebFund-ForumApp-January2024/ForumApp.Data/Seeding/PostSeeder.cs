using ForumApp.Data.Models;

namespace ForumApp.Data.Seeding

{

    class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currPost;
            currPost = new Post()
            {
                Title = "My First Post",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ullamcorper, risus quis fermentum lacinia, dui nisi posuere nisl, eget dictum.",
            };
            posts.Add(currPost);

            currPost = new Post()
            {
                Title = "My Second Post",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu lacinia turpis. Quisque eu dapibus sem. Mauris pharetra ultrices leo.",
            };
            posts.Add(currPost);
            
            currPost = new Post()
            {
                Title = "My Third Post",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer lacinia nibh a risus hendrerit tincidunt. Donec porta nulla arcu, at.",
            };
            posts.Add(currPost);

            return posts.ToArray();
        }
    }
}
