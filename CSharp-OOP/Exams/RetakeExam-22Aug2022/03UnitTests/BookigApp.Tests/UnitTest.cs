using NUnit.Framework;
using System;
using FrontDeskApp;

namespace BookingApp.Tests
{
    public class Tests
    {
        Room room;
        Hotel hotel;
        [SetUp]
        public void Setup()
        {
            room = new Room(2, 25.0);
            hotel = new Hotel("HotelName", 3);
        }

        [Test]
        public void RoomConstructorSetsNameCorrectly()
        {
            int bedCapacity = 2;
            double price = 24.5;

            Room room = new Room(bedCapacity, price);
            Assert.IsTrue(room.BedCapacity == bedCapacity && room.PricePerNight == price);
        }

        [TestCase(-60)]
        [TestCase(0)]
        public void BedCapacityCannotBeZeroOrNegative(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() => room = new Room(bedCapacity, 35.0));
        }

        [TestCase(-4.50)]
        [TestCase(0)]
        public void PriceCannotBeZeroOrNegative(double price)
        {
            Assert.Throws<ArgumentException>(() => room = new Room(2, price));
        }

        [Test]
        public void BookingProperValues()
        {
            int bookingNumber = 10;
            int residenceDuration = 4;
            int adults = 2;
            int child = 1;
            Booking booking = new Booking(bookingNumber,room , residenceDuration);
            Assert.True(booking.BookingNumber == bookingNumber &&
                        booking.ResidenceDuration == residenceDuration);
        }

        [Test]
        public void HotelProperValues()
        {
            string hotelName = "HotelName";
            int category = 3;
            hotel = new Hotel(hotelName, category);
            Assert.IsTrue(hotel.FullName == hotelName &&
                          hotel.Category == category &&
                          hotel.Rooms != null &&
                          hotel.Bookings != null);
        }

        [TestCase("")]
        [TestCase(null)]
        public void HotelFullNameCannotBeNullOrWhiteSpace(string hotelName)
        {
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(hotelName, 3));
        }

        [TestCase(0)]
        [TestCase(6)]
        public void HotelCategoryShouldBeBetweenOneAndFive(int category)
        {
            Assert.Throws<ArgumentException>(() => hotel = new Hotel("HotelName", category));
        }

        [Test]
        public void HotelAddRoomIncreasesCountOfTheCollectionWhenRoomAdded()
        {
            hotel.AddRoom(room);
            Assert.AreEqual(hotel.Rooms.Count, 1);
        }

        [TestCase(-5)]
        [TestCase(0)]
        public void HotelBookRoomNotANegativeOrZero(int adults)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 2, 4, 600.00));
        }

        [TestCase(-5)]
        public void HotelBookRoomNotANegative(int childs)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, childs, 4, 600.00));
        }

        [TestCase(0)]
        public void HotelBookRoomNotLessThanOne(int duration)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, duration, 600.00));
        }

        [Test]
        public void BookRoomAddsABooking()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 4, 200.0);
            Assert.AreEqual(hotel.Bookings.Count, 1);
        }

        [Test]
        public void BookRoomDoesNotBookIfCapacityIsLowerThanBeds()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(2, 1, 4, 200.0);
            Assert.AreEqual(hotel.Bookings.Count, 0);
        }

        [Test]
        public void BookRoomGeneratesAProperTurnOver()
        {
            int duration = 4;
            double price = room.PricePerNight;
            double expected = duration * price;

            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, duration, 500.0);
            Assert.AreEqual(expected, hotel.Turnover);
        }
    }
}
