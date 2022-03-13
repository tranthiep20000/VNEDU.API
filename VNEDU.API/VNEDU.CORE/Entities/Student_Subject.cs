using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Entities
{
    /// <summary>
    /// Thông tin của Student_Subject
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public class Student_Subject
    {
        /// <summary>
        /// Khóa chính bảng Student
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Khóa chính bảng Subject
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Khóa chính bảng học kì
        /// </summary>
        public int SemesterId { get; set; }

        /// <summary>
        /// Khóa chính bảng SchoolYear
        /// </summary>
        public int SchoolYearId { get; set; }

        /// <summary>
        /// Khóa chính bảng DetailedTableScore
        /// </summary>
        public int DetailedTableScoreId { get; set; }

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
