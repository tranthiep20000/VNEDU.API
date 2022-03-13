using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Services
{
    /// <summary>
    /// Giao diện dịch vụ của Student_Subject
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public interface IStudent_SubjectService
    {
        /// <summary>
        /// Xử lý nghiệp vụ thêm dữ liệu
        /// </summary>
        /// <param name="student_Subject">student_Subject</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(04/03/2022)
        int Insert(Student_Subject student_Subject);

        /// <summary>
        /// Xử lý nghiệp vụ xóa dữ liệu
        /// </summary>
        /// <param name="StudentId">Khóa chính bảng Student</param>
        /// <param name="SchoolYearId">Khóa chính bảng SchoolYear</param>
        /// <param name="SemesterId">Khóa chính bảng Semester</param>
        /// <param name="SubjectId">Khóa chính bảng Subject</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(0)
        int Delete(int StudentId, int SubjectId, int SemesterId, int SchoolYearId);
    }
}
