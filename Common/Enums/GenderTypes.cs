using System.ComponentModel;

namespace Common.Enums
{
    public enum GenderType : byte
    {
        /// <summary>
        /// Женщина
        /// </summary>
        [Description("Woman")]
        Woman = 1,

        /// <summary>
        /// Мужчина
        /// </summary>
        [Description("Man")]
        Man = 2,

        /// <summary>
        /// Другое
        /// </summary>
        [Description("Another")]
        Another = 3
    }
}
