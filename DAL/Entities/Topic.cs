using Common.Interfaces;
using System.Collections.Generic;

namespace DAL.Entities
{
    /// <summary>
    /// Topic
    /// </summary>
    public class Topic : IIdHasInt
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Topic name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Topic Cards
        /// </summary>
        public IEnumerable<Card> Cards { get; set; }
    }
}
