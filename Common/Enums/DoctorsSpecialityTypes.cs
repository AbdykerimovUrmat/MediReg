using System.ComponentModel;

namespace Common.Enums
{
    public enum DoctorsSpecialtyType
    {
        /// <summary>
        /// Педиатр
        /// </summary>
        [Description("Psychiatrist")]
        Pediatrician = 1,

        /// <summary>
        /// Терапевт
        /// </summary>
        [Description("Internist")]
        Internist = 2,

        /// <summary>
        /// Психиатр
        /// </summary>
        [Description("Psychiatrist")]
        Psychiatrist = 3
    }
}
