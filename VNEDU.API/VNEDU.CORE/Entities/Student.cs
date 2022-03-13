using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Entities
{
    /// <summary>
    /// Thông tin học sinh
    /// CreatedBy: TTThiep(03/03/2022)
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Mã học sinh
        /// </summary>
        public string? StudentCode { get; set; }

        /// <summary>
        /// Tên học sinh
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
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
