namespace Student.Managerment.API.Models
{
    /// <summary>
    /// Thông tin học kì
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    public class Semester
    {
        #region propertys
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int SemesterId { get; set; }

        /// <summary>
        /// Tên học kì
        /// </summary>
        public string? SemesterName { get; set; }
        #endregion
    }
}
