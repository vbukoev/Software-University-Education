namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Hotels.Contacts;
    using Contracts;

    public class HotelRepository :IRepository<IHotel>
    {
        private List<IHotel> hotels;

        public HotelRepository()
        {
            this.hotels = new List<IHotel>();   
        }
        public void AddNew(IHotel model)
        {
            hotels.Add(model);
        }

        public IHotel Select(string criteria)
            => hotels.FirstOrDefault(x => x.FullName == criteria);

        public IReadOnlyCollection<IHotel> All()
            => hotels;
    }
}
