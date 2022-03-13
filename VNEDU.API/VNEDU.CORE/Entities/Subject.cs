using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Entities
{
    /// <summary>
    /// Thông tin môn học
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Tên môn học
        /// </summary>
        public string? SubjectName { get; set; }

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
