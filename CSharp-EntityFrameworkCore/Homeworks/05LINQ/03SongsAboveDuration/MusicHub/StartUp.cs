using System.Text;
using MusicHub.Data.Models;

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
            //var albumsInfo = context
            //    .Producers
            //    .First(x => x.Id == producerId)
            //    .Albums
            //    .Select(x => new
            //    {
            //        AlbumName = x.Name,
            //        ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
            //        ProducerName = x.Producer.Name,
            //        Songs = x.Songs.Select(s => new
            //            {
            //                SongName = s.Name,
            //                SongPrice = s.Price,
            //                SongWriterName = s.Writer.Name
            //            })
            //            .OrderByDescending(s => s.SongName)
            //            .ThenBy(s => s.SongWriterName),
            //        AlbumPrice = x.Price
            //    })
            //    .OrderByDescending(x => x.AlbumPrice)
            //    .ToArray();

            //StringBuilder sb = new StringBuilder();

            //foreach (var a in albumsInfo)
            //{
            //    sb
            //        .AppendLine($"-AlbumName: {a.AlbumName}")
            //        .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
            //        .AppendLine($"-ProducerName: {a.ProducerName}")
            //        .AppendLine($"-Songs:");

            //    int cnt = 1;

            //    if (a.Songs.Any())
            //    {
            //        foreach (var s in a.Songs)
            //        {
            //            sb
            //                .AppendLine($"---#{cnt++}")
            //                .AppendLine($"---SongName: {s.SongName}")
            //                .AppendLine($"---Price: {s.SongPrice:f2}")
            //                .AppendLine($"---Writer: {s.SongWriterName}");
            //        }
            //    }

            //    sb.AppendLine($"-AlbumPrice: {a.AlbumPrice:f2}");
            //}
            //return sb.ToString().TrimEnd();

            throw new NotImplementedException(); // this has to be commented when submitted in judge for task 2!!!
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsAboveDuration = context
                .Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers
                                         .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                                         .OrderBy(name => name)
                                         .ToList(),
                    WriterName = s.Writer.Name,
                    AlbumProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();



            StringBuilder sb = new StringBuilder();
            int cnt = 1;
            foreach (var s in songsAboveDuration)
            {
                sb
                    .AppendLine($"-Song #{cnt++}")
                    .AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.WriterName}");
                if (s.PerformerFullName.Any())
                {
                    sb
                        .AppendLine(string.Join(Environment.NewLine, s.PerformerFullName
                            .Select(x => $"---Performer: {x}")));
                }

                sb
                    .AppendLine($"---AlbumProducer: {s.AlbumProducerName}")
                    .AppendLine($"---Duration: {s.Duration}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
