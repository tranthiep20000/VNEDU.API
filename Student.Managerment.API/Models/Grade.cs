namespace Student.Managerment.API.Models
{
    /// <summary>
    /// Thông tin khối
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    public class Grade
    {
        #region propertys
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// Tên khối
        /// </summary>
        public string? GradeName { get; set; }
        #endregion

    }
}
