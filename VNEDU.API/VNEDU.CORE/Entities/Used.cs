using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Entities
{
    /// <summary>
    /// Thông tin người dùng
    /// CreatedBy: TTThiep(01/03/2022)
    /// </summary>
    public class Used
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string? UserName  { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Khóa chính bảng quyền
        /// </summary>
        public int? DecentralizationId { get; set; }
    }
}
