
using Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Vacancy : IIdHas<string>
    {
        public string Id { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string UserId { get; set; }
    }
}
