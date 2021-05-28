using System.Collections.Generic;

namespace Models.Tables
{
    public abstract class TopicModel
    {
        public class Base
        {
            /// <summary>
            /// Название темы
            /// </summary>
            public string Name { get; set; }
        }

        public class Get : Base
        {
            /// <summary>
            /// Код
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Карты темы
            /// </summary>
            public IEnumerable<CardModel.Get> Cards { get; set; }
        }

        public class Add : Base { }
    }
}
