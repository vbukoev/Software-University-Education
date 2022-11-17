namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int maxBedCapacity = 4;
        public Studio() : base(maxBedCapacity)
        {
        }
    }
}
