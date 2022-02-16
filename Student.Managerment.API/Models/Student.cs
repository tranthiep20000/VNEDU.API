namespace Student.Managerment.API.Models
{
    /// <summary>
    /// thông tin học sinh
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    public class Student
    {
        #region propertys
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Mã học sinh
        /// </summary>
        public string? StudentCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string? PassWord { get; set; }

        /// <summary>
        /// Khóa chính bảng khối
        /// </summary>
        public int? GradeId { get; set; }

        /// <summary>
        /// Khóa chính bảng lớp học
        /// </summary>
        public int? ClassId { get; set; }

        /// <summary>
        /// Khóa chính bảng phân quyền
        /// </summary>
        public int DecentralizationId { get; set; }
        #endregion
    }
}
