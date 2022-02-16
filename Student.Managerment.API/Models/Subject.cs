namespace Student.Managerment.API.Models
{
    /// <summary>
    /// Thông tin môn học
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    public class Subject
    {
        #region propertys
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Tên môn học
        /// </summary>
        public string? SubjectName { get; set; }
        #endregion

    }
}
