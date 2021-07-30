using System.Collections.Generic;

namespace Models.Tables
{
    public abstract class TopicModel
    {
        public class ByIdOut
        {
            /// <summary>
            /// Код
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Название темы
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Карты темы
            /// </summary>
            public IEnumerable<CardModel.ByIdOut> Cards { get; set; }
        }

        public class AddIn
        {
            /// <summary>
            /// Название темы
            /// </summary>
            public string Name { get; set; }
        }
    }
}
