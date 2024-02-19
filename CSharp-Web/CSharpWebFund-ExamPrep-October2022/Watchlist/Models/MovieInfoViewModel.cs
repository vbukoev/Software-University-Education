namespace Watchlist.Models
{
    public class MovieInfoViewModel
    {
        public MovieInfoViewModel(int id, string title, string director, string imageUrl, decimal rating, string genre)
        {
            Id = id;
            Title = title;
            Director = director;
            ImageUrl = imageUrl;
            Rating = rating;
            Genre = genre;
        }
        /// <summary>
        /// Movie Identifier
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// Movie Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Movie Director
        /// </summary>
        public string Director { get; set; }
        /// <summary>
        /// Movie Image path
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        ///Movie Rating
        /// </summary>
        public decimal Rating { get; set; }
        /// <summary>
        /// Movie Genre
        /// </summary>
        public string Genre{ get; set; }
    }
}

