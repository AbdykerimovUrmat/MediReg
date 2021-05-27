
using Common.Interfaces;

namespace Models.Tables
{
    /// <summary>
    /// Card Model
    /// </summary>
    public abstract class CardModel
    {
        /// <summary>
        /// Base Class
        /// </summary>
        public class Base
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
        }

        public class Get : Base, IIdHas<int>
        {
            /// <summary>
            /// Card Id
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// User
            /// </summary>
            public UserModel.Get User { get; set; }

            /// <summary>
            /// Topic
            /// </summary>
            public TopicModel.Get Topic { get; set; }
        }

        public abstract class AddEditBase : Base
        {
            /// <summary>
            /// User Id
            /// </summary>
            public string UserId { get; set; }

            /// <summary>
            /// Topic Id
            /// </summary>
            public string TopicId { get; set; }
        }

        public class Add : AddEditBase { }

        public class Edit : AddEditBase, IIdHasInt 
        { 
            /// <summary>
            /// Id
            /// </summary>
            public int Id { get; set; }
        }
    }
}
