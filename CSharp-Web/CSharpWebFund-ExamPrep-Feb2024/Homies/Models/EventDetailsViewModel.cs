namespace Homies.Models
{
    public class EventDetailsViewModel
    {
        /// <summary>
        /// Event Identifier
        /// </summary>
        public int Id { get; set; } 
        /// <summary>
        /// Event Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Event Description
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Event Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Event Start Date and Time
        /// </summary>
        public string Start { get; set; } = string.Empty;
        /// <summary>
        /// Event End Date and Time
        /// </summary>
        public string End { get; set; } = string.Empty;
        /// <summary>
        /// Event Organiser
        /// </summary>
        public string Organiser { get; set; } = string.Empty;
        /// <summary>
        /// Event Creation Date 
        /// </summary>
        public string CreatedOn { get; set; } = string.Empty;
    }
}
