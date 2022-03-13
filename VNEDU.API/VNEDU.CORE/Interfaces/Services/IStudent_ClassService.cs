using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Services
{
    /// <summary>
    /// Giao diện dịch vụ Student_Class
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public interface IStudent_ClassService
    {
        /// <summary>
        /// Xử lý nghiệp vụ thêm dữ liệu
        /// </summary>
        /// <param name="student_Class">Student_Class</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(04/03/2022)
        int Insert(Student_Class student_Class);

        /// <summary>
        /// Xử lý nghiệp vụ xóa dữ liệu
        /// </summary>
        /// <param name="StudentId">Khóa chính bảng Student</param>
        /// <param name="SchoolYearId">Khóa chính bảng SchoolYear</param>
        /// <param name="SemesterId">Khóa chính bảng Semester</param>
        /// <param name="ClassId">Khóa chính bảng Class</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(0)
        int Delete(int StudentId, int ClassId, int SemesterId, int SchoolYearId);
    }
}
