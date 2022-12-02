// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using System.Linq;
using FestivalManager.Entities;//without this when SUBMITTING THE SOLUTION IN JUDGE!!!
using NUnit.Framework.Internal;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
        private const string songName = "name";
        private TimeSpan duration = new TimeSpan(0, 2, 18);
        private const string firstPerformerName = "firstname";
        private const string lastPerformerName = "lastname";
        private const int age = 18;

        private Song song;
        private Performer performer;
        private Stage stage;

        [SetUp]
        public void SetUp()
        {
            song = new Song(songName, duration);
            performer = new Performer(firstPerformerName, lastPerformerName, age);
            stage = new Stage();
            stage.AddPerformer(performer);
            stage.AddSong(song);
        }

       

        [Test]
        public void AddPerformerAddsPerformerCorrectly()
        {
            Assert.AreEqual(stage.Performers.Count,1);
            Assert.AreEqual(stage.Performers.First(), performer);
        }

        [TestCase(17)]
        [TestCase(13)]
        [TestCase(1)]
        public void AddPerformerThrowsForUnder18(int age)
        {
            Assert.Throws<ArgumentException>(() =>
                stage.AddPerformer(new Performer(firstPerformerName, lastPerformerName, age)));
        }

        [TestCase(59)]
        [TestCase(14)]
        [TestCase(1)]
        public void AddSongThrowsForUnder1Minute(int sec)
        {
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("fake_name", new TimeSpan(0, 0, sec))));
        }

        [Test]
        public void AddSongToPerformerReturnsCorrectValue()
        {
            Assert.AreEqual(stage.AddSongToPerformer(song.Name, performer.FullName), $"{song} will be performed by {performer}");
        }

        [Test]
        public void PlayReturnsCorrectOutput()
        {
            stage.AddSongToPerformer(song.Name, performer.FullName);
            stage.AddSongToPerformer(song.Name, performer.FullName);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            var songsCount = this.stage.Performers.Sum(p => p.SongList.Count());

            Assert.AreEqual(stage.Play(), $"{stage.Performers.Count} performers played {songsCount} songs");
        }

        [Test]
        public void TestThrowsWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(songName, null));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, firstPerformerName));

        }

    }
}