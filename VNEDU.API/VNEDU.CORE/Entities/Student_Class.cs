using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Entities
{
    /// <summary>
    /// Thông tin của Student_Class
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public class Student_Class
    {
        /// <summary>
        /// Khóa chính bảng Student
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Khóa chính bảng Class
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Khóa chính bảng Semester
        /// </summary>
        public int SemesterId { get; set; }

        /// <summary>
        /// Khóa chính bảng SchoolYear
        /// </summary>
        public int SchoolYearId { get; set; }

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
