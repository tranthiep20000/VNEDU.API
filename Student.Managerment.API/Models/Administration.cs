namespace Student.Managerment.API.Models
{
    /// <summary>
    /// Thông tin admin
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    public class Administration
    {
        #region propertys
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int AdministrationId { get; set; }

        /// <summary>
        /// Mã admin
        /// </summary>
        public string? AdministrationCode { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string? PassWord { get; set; }

        /// <summary>
        /// Khóa chính bảng phân quyền
        /// </summary>
        public int? DecentralizationId { get; set; }
        #endregion

    }
}
