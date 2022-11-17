using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this.rooms.Add(model);
        }

        public IRoom Select(string criteria)
            => rooms.FirstOrDefault(x => x.GetType().Name == criteria);

        public IReadOnlyCollection<IRoom> All()
        => rooms;
    }
}
