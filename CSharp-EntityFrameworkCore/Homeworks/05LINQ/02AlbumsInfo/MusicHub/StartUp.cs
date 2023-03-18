using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context
                .Producers
                .First(x => x.Id == producerId)
                .Albums
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName),
                    AlbumPrice = x.Price
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var a in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {a.AlbumName}")
                    .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                    .AppendLine($"-ProducerName: {a.ProducerName}")
                    .AppendLine($"-Songs:");
                
                int cnt = 1;

                if (a.Songs.Any())
                {
                    foreach (var s in a.Songs)
                    {
                        sb
                            .AppendLine($"---#{cnt++}")
                            .AppendLine($"---SongName: {s.SongName}")
                            .AppendLine($"---Price: {s.SongPrice:f2}")
                            .AppendLine($"---Writer: {s.SongWriterName}");
                    }
                }

                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
