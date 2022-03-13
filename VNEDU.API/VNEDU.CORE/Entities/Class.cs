using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Entities
{
    /// <summary>
    /// Thông tin lớp học
    /// CreatedBy: TTThiep(03/03/2022)
    /// </summary>
    public class Class
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Tên lớp học
        /// </summary>
        public string? ClassName { get; set; }

        /// <summary>
        /// Khóa chính bảng năm học
        /// </summary>
        public int? SchoolYearId { get; set; }

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
