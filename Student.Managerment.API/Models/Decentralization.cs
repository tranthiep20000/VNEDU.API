namespace Student.Managerment.API.Models
{
    /// <summary>
    /// Thông tin phân quyền
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    public class Decentralization
    {
        #region propertys
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int DecentralizationId { get; set; }

        /// <summary>
        /// Tên quyền
        /// </summary>
        public string? DecentralizationName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string? DescriptionName { get; set; }
        #endregion

    }
}
