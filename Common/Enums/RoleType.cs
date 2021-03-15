using System.ComponentModel;

namespace Common.Enums
{
    public enum RoleType : byte
    {
        /// <summary>
        /// Admin
        /// </summary>
        [Description("Admin")]
        Admin = 1,

        /// <summary>
        /// Doctor
        /// </summary>
        [Description("Doctor")]
        Doctor = 2,

        /// <summary>
        /// PatientManager
        /// </summary>
        [Description("PatientManager")]
        PatientManager = 3,

        /// <summary>
        /// Patient
        /// </summary>
        [Description("Patient")]
        Patient = 4,
    }
}
