using Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    /// <summary>
    /// Card
    /// </summary>
    public class Card : IIdHas<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Price for a work time
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Work time in minutes
        /// </summary>
        public int WorkTimeInMinutes { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// User who created topic
        /// </summary>
        [ForeignKey("UserId")]
        public User User { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Topic
        /// </summary>
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        /// <summary>
        /// Topic Id
        /// </summary>
        public int? TopicId { get; set; }
    }
}
