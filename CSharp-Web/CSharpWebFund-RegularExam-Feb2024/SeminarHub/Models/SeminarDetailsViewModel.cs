namespace SeminarHub.Models
{
    public class SeminarDetailsViewModel
    {
        /// <summary>
        /// Seminar Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Seminar Topic
        /// </summary>
        public string Topic { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Lecturer
        /// </summary>
        public string Lecturer { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Date and Time
        /// </summary>
        public string DateAndTime { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Organizer
        /// </summary>
        public string Organizer { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Category
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Details
        /// </summary>
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Duration
        /// </summary>
        public int Duration { get; set; }
    }
}
