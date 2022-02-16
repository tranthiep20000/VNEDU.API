namespace Student.Managerment.API.Models
{
    /// <summary>
    /// Thông tin lớp học
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    public class Class
    {
        #region propertys
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Tên lớp học
        /// </summary>
        public string? ClassName { get; set; }

        /// <summary>
        /// Khóa chính bảng khối
        /// </summary>
        public int? GradeId { get; set; }
        #endregion


    }
}
