using System;

namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;


    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        [SetUp]
        public void SetUp()
        {
            Person[] persons = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Gogi"),
                new Person(4, "Metodi"),
                new Person(5, "Stojan"),
                new Person(6, "Anatoli"),
                new Person(7, "Petar"),
                new Person(8, "Emo"),
                new Person(9, "Chichi"),
                new Person(10, "Lyuval"),
                new Person(11, "Panayot"),
            };
            this.db = new Database(persons);
        }

        [Test]
        public void ConstructorShouldNotTakeMoreThan16Persons()
        {
            Person[] persons = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Gogi"),
                new Person(4, "Metodi"),
                new Person(5, "Stojan"),
                new Person(6, "Anatoli"),
                new Person(7, "Petar"),
                new Person(8, "Emo"),
                new Person(9, "Chichi"),
                new Person(10, "Lyuval"),
                new Person(11, "Panayot"),
                new Person(12, "Lada"),
                new Person(13, "aerw"),
                new Person(14, "gsd"),
                new Person(15, "asht"),
                new Person(16, "opi"),
                new Person(17, "kka"),
            };
            Assert.Throws<ArgumentException>(() =>
            {
                db = new Database(persons);
            });
        }

        [Test]
        public void AddShouldIncreaseTheCollectionCount()
        {
            db.Add(new Person(14, "Joe"));

            Assert.AreEqual(db.Count, 12);
        }

        [Test]
        public void AddCannotAddPersonWhichAlreadyExistsWithThisId()
        {
            Assert.That(()=>db.Add(new Person(10, "A")), Throws.InvalidOperationException);
        }

        [Test]
        public void AddCannotAddPersonWithTheSameName()
        {
            Assert.That(() => db.Add(new Person(1, "A")), Throws.InvalidOperationException);
        }

        //[Test]
        //public void AddShouldNotExceedMaxArrayCount()
        //{
        //    db.Add(new Person(14, "Fourteen"));
        //    db.Add(new Person(15, "Fifteen"));
        //    Assert.That(()=>db.Add(new Person(16, "Error")), Throws.InvalidOperationException);
        //}

        [Test]
        public void AddAddsPersonToTheCollection()
        {
            Person person = new Person(16, "Niki");
            db.Add(person);
            Person expectedPerson = db.FindById(16);
            Assert.AreEqual(person, expectedPerson);
        }

        [Test]
        public void RemoveLastPersonFromOurCollection()
        {
            Person person = new Person(16, "Niki");
            db.Add(person);
            db.Remove();
            Assert.That(()=>db.FindByUsername("Niki"), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldNotFunctionWhenTheCollectionIsEmpty()
        {
            Database db = new Database();
            Assert.That(()=>db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void RemovesShouldDecreaseTheCollection()
        {
            int expected = db.Count - 1;
            db.Remove();
            Assert.AreEqual(db.Count, expected);
        }

        [Test]
        public void FindByUsernameThrowsExceptionWhenUsernameIsNotInTheCollection()
        {
            Assert.That(()=>db.FindByUsername("Niki"), Throws.InvalidOperationException);
        }

        [TestCase("")]
        [TestCase(null)]
        public void InFindByUsernameAllUsersShouldNotBeNull(string username)
        { 
            Assert.That(()=>db.FindByUsername(username),Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameReturnsTheCorrectResultAsAPerson()
        {
            Person person = db.FindByUsername("Pesho");
            Assert.AreEqual(person.UserName, "Pesho");
        }

        [Test]
        public void FindByIdReturnsTheCorrectResultAsAPerson()
        {
            Person person = db.FindById(1);
            Assert.AreEqual(person.Id, 1);
        }

        [Test]
        public void FindByIdPositiveNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-3));
        }

        [Test]
        public void FindByIdThrowsAnExceptionWhenThereAreNoExistingIdsWhichPassed()
        {
            Assert.That(() => db.FindById(9239239423), Throws.InvalidOperationException); //the id 9239239423 should be a very big one which won't exist
        }
    }
}