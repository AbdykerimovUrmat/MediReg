using Common.Enums;

namespace Models.Tables
{
    public class DoctorModel
    {
        public class Base : UserModel
        {
            /// <summary>
            /// Специальность доктора
            /// </summary>
            public DoctorsSpecialtyType Speciality { get; set; }
        }
    }
}
