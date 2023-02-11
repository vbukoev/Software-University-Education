using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Database.Tests
{
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            db = new Database();
        }
        //valid functionality of the ctor
        //1->edge case(no data); 2,3->valid data ,4->edge case (max data)
        //this test is meant to test the ctor and nothing more(single responsibility)
        //fetch() is working fine here

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })] // valid
        [TestCase(new int[] { 1, 2, 3 })] //valid but with 3 elements
        [TestCase((new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }))]
        public void ConstructorShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            //arrange
            Database testDatabase = new Database(elementsToAdd);
            //act
            int[] actualData = testDatabase.Fetch();
            int[] expectedData = elementsToAdd;
            int actualCount = testDatabase.Count;
            int expectedCnt = expectedData.Length;
            //assert 
            CollectionAssert.AreEqual(expectedData, actualData,
                "Database constructor should initialize data field correctly!");

            Assert.AreEqual(expectedCnt, actualCount,
                "Constructor should set initial value for count field!");

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        //1-invalid elements
        //2-edge case with 17 elements but again invalid
        public void ConstructorMustNotAllowToExceedMaximumCount(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database tesDatabase = new Database(elementsToAdd);

            }, "Array's capacity must be exactly 16 integers!");
        }

        //Valid functionality of count and ctor working properly
        [Test]
        public void CountMustReturnActualCount()
        {
            int[] initData = new int[] { 1, 2, 3 };
            Database testDatabase = new Database(initData);

            int actual = testDatabase.Count;
            int expected = initData.Length;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountMustReturnZeroWhenNoElements()
        {
            int actual = this.db.Count;
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 })] 
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            foreach (var el in elementsToAdd) db.Add(el);

            int[] actualData = db.Fetch();
            int[] expectedData = elementsToAdd;

            int actual = db.Count;
            int expected = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData, "Add should add elements physically to the field!");
            Assert.AreEqual(expected, actual, "Add should change the elements count when add!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingMoreThan16Elements()
        {
            for (int i = 0; i < 16; i++)
            {
                db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] {1,2,3,4,5})]
        [TestCase(new int[] {1})]
        public void RemoveMethodShouldRemoveTheLastElementOnce(int[] startInts)
        {
            foreach (var el in startInts)
            {
                db.Add(el);
            }
            this.db.Remove();
            List<int> eList = new List<int>(startInts);
            eList.RemoveAt(eList.Count - 1);
            int[] actual = db.Fetch();
            int[] expected = eList.ToArray();

            int actualCnt = db.Count;
            int expectedCnt = expected.Length;

            CollectionAssert.AreEqual(expected, actual, 
                "Remove should remove elements physically to the field!");
            Assert.AreEqual(expectedCnt, actualCnt, 
                "Remove should decrement the count of the database!");
        }

        [Test]
        public void RemoveShouldRemoveTheLastElementMoreThanOnceWhenCalled()
        {
            List<int> initData = new List<int>() { 1, 2, 3 };

            foreach (var el in initData)
            {
               db.Add(el); 
            }

            for (int i = 0; i < initData.Count; i++)
            {
                db.Remove();
            }
            int[] actual = db.Fetch();
            int[] expected = new int[] {};

            int actualCnt = db.Count;
            int expectedCnt = 0;

            CollectionAssert.AreEqual(expected, actual, 
                "Remove should remove elements physically to the field!");
            Assert.AreEqual(expectedCnt, actualCnt, 
                "Remove should decrement the count of the database!");
        }

        [Test]
        public void RemoveShouldThrowErrorWhenNoElementsFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] {})]
        [TestCase(new int[] {1})]
        [TestCase(new int[] {1,2,3})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyArray(int[] initInts)
        {
            foreach (var el in initInts)
            {
                db.Add(el);
            }

            int[] actualResult = db.Fetch();
            int[] expectedResult = initInts;

            CollectionAssert.AreEqual(expectedResult, actualResult,
                "Fetch should return copy of existing data!");
        }
    }
}
