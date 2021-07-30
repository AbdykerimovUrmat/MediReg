
using Common.Interfaces;

namespace Models.Tables
{
    /// <summary>
    /// Card Model
    /// </summary>
    public abstract class CardModel
    {
        public class ByIdOut : IIdHas<int>
        {
            /// <summary>
            /// Price for a work time
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// Work Time in minutes
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
            /// Card Id
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// User
            /// </summary>
            public UserModel.ByIdOut User { get; set; }

            /// <summary>
            /// Topic
            /// </summary>
            public TopicModel.ByIdOut Topic { get; set; }
        }

        public class ListOut : IIdHas<int>
        {
            /// <summary>
            /// Price for a work time
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// Work Time in minutes
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
            /// Card Id
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// User
            /// </summary>
            public UserModel.ByIdOut User { get; set; }

            /// <summary>
            /// Topic
            /// </summary>
            public TopicModel.ByIdOut Topic { get; set; }
        }

        public class AddIn
        {
            /// <summary>
            /// Price for a work time
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// Work Time in minutes
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
            /// User Id
            /// </summary>
            public string UserId { get; set; }

            /// <summary>
            /// Topic Id
            /// </summary>
            public string TopicId { get; set; }
        }

        public class EditIn : IIdHasInt 
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
            /// Work Time in minutes
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
            /// User Id
            /// </summary>
            public string UserId { get; set; }

            /// <summary>
            /// Topic Id
            /// </summary>
            public string TopicId { get; set; }
        }
    }
}
