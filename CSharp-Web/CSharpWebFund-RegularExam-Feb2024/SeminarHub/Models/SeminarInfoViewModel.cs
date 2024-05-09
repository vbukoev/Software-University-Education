using SeminarHub.Data;

namespace SeminarHub.Models
{
    public class SeminarInfoViewModel
    {
        public SeminarInfoViewModel(int id, string topic, string lecturer, DateTime dateAndTime, string organizer, string category)
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            DateAndTime = dateAndTime.ToString(DataConstants.DateTimeFormat);
            Organizer = organizer;
            Category = category;
        }

        /// <summary>
        /// Seminar Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Seminar Topic
        /// </summary>
        public string Topic { get; set; } 

        /// <summary>
        /// Seminar Lecturer
        /// </summary>
        public string Lecturer { get; set; } 

        /// <summary>
        /// Seminar Date and Time
        /// </summary>
        public string DateAndTime { get; set; }

        /// <summary>
        /// Seminar Organizer
        /// </summary>
        public string Organizer { get; set; }

        /// <summary>
        /// Seminar Category
        /// </summary>
        public string Category { get; set; } 
    }
}
