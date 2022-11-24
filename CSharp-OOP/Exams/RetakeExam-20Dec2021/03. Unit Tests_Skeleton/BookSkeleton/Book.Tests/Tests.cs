namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book;

        private const string BOOKNAME = "Test";
        private const string AUTHOR = "Author";

        private const int FOOTNOTENUMBER = 1;
        private const string FOOTNOTETEXT = "Text";

        [SetUp]
        public void SetUp()
        {
            book = new Book(BOOKNAME, AUTHOR);
            book.AddFootnote(FOOTNOTENUMBER, FOOTNOTETEXT);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.True(book.BookName == BOOKNAME &&
                        book.Author == AUTHOR &&
                        book.FootnoteCount == 1);
        }

        [TestCase("")]
        [TestCase(null)]
        public void BookNameThrowsForNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => book = new Book(name, AUTHOR));
        }


        [TestCase("")]
        [TestCase(null)]
        public void AuthorThrowsForNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => book = new Book(BOOKNAME, name));
        }

        [Test]
        public void FootNoteThrowsWhenAlreadyExisting()
        {
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(FOOTNOTENUMBER, "Text"));
        }

        [Test]
        public void AddFootnoteIncreasesCount()
        {
            Assert.AreEqual(book.FootnoteCount,1);
        }

        [Test]
        public void FindFootnoteThrowsForNonExistingFootnote()
        {
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(321));
        }

        [Test]
        public void FindFootnoteReturnsCorrectResult()
        {
            Assert.AreEqual($"Footnote #{FOOTNOTENUMBER}: {FOOTNOTETEXT}", book.FindFootnote(FOOTNOTENUMBER));
        }

        [Test]
        public void AlterFootnoteThrowsWhenThereIsNotAFootnoteNumber()
        {
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(15, "test"));
        }

        [Test]
        public void AlterFootnoteChangesText()
        {
            string test = "test text";
            book.AlterFootnote(FOOTNOTENUMBER, test);
            Assert.AreEqual($"Footnote #{FOOTNOTENUMBER}: {test}", book.FindFootnote(FOOTNOTENUMBER));
        }
    }
}