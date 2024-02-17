using Homies.Data;

namespace Homies.Models
{
    public class EventInfoViewModel
    {
        public EventInfoViewModel(int id, string name, DateTime start, string type, string organiser)
        {
            Id = id;
            Name = name;
            Start = start.ToString(DataConstants.DateTimeFormat);
            Type = type;
            Organiser = organiser;
        }
        /// <summary>
        /// Event Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Event Name
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// Event Start Date and Time
        /// </summary>
        public string Start { get; set; } 

        /// <summary>
        /// Event Type
        /// </summary>
        public string Type { get; set; } 

        /// <summary>
        /// Event Organiser
        /// </summary>
        public string Organiser { get; set; } 
    }
}
