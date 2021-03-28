using System.ComponentModel.DataAnnotations.Schema;
using Common.Enums;

namespace DAL.Entities
{
    public class Doctor : User
    {
        /// <summary>
        /// Специальность 
        /// </summary>
        public DoctorsSpecialtyType Speciality { get; set; }
    }
}
