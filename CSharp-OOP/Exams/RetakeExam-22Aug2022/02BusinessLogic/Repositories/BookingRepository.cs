namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Models.Bookings.Contracts;
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IBooking Select(string criteria)
            => bookings.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);

        public IReadOnlyCollection<IBooking> All()
            => bookings;
    }
}
