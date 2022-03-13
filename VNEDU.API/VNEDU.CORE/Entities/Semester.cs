using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Entities
{
    /// <summary>
    /// Thông tin học kì
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public class Semester
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int SemesterId { get; set; }

        /// <summary>
        /// Tên học kì
        /// </summary>
        public string? SemesterName { get; set; }

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
