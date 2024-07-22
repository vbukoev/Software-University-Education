namespace SeminarHub.Models
{
    public class SeminarDeleteViewModel
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
        /// Seminar Date and Time
        /// </summary>
        public DateTime DateAndTime { get; set; }
    }
}
