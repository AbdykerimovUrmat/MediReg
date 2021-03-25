using System.ComponentModel.DataAnnotations.Schema;
using Common.Enums;

namespace DAL.Entities
{
    [Table("Doctors")]
    public class Doctor : User
    {
        public DoctorsSprecialtyType Speciality { get; set; }
    }
}
