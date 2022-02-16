namespace Student.Managerment.API.Models
{
    /// <summary>
    /// Thông tin năm học
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    public class SchoolYear
    {
        #region propertys
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int SchoolYearId { get; set; }

        /// <summary>
        /// Tên năm học
        /// </summary>
        public string? SchoolYearName { get; set; }
        #endregion


    }
}
