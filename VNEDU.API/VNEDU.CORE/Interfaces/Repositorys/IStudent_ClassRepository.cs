using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triển khai Student_Class
    /// </summary>
    public interface IStudent_ClassRepository
    {
        /// <summary>
        /// Lấy thông tin theo học kì, năm học, lớp học 
        /// </summary>
        /// <returns>Danh sách thông tin</returns>
        /// CreatedBy: TTThiep(04/03/2022)
        Object Get(int SchoolYearId, int SemesterId, int ClassId);

        /// <summary>
        /// Lấy thông tin theo học kì, năm học, học sinh
        /// </summary>
        /// <returns>Danh sách thông tin</returns>
        /// CreatedBy: TTThiep(04/03/2022)
        object GetClassByStudentSchoolYearSemester(int StudentId, int SchoolYearId, int SemesterId);

        /// <summary>
        /// Thêm thông tin của Student_Class
        /// </summary>
        /// <param name="student_Class">Student_Class</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(04/03/2022)
        int Insert(Student_Class student_Class);

        /// <summary>
        /// Xóa thông tin của Student_Class 
        /// </summary>
        /// <param name="StudentId">Khóa chính bảng Student</param>
        /// <param name="SchoolYearId">Khóa chính bảng SchoolYear</param>
        /// <param name="SemesterId">Khóa chính bảng Semester</param>
        /// <param name="ClassId">Khóa chính bảng Class</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(04/03/2022)
        int Delete(int StudentId, int ClassId, int SemesterId, int SchoolYearId);
        object CheckStudentClass(int SchoolYearId, int SemesterId, int ClassId, int StudentId);

        Object GetPagingStudentClassByClassSemesterSchoolYear(int SchoolYearId, int SemesterId, int ClassId, string? ValueFilter, int PageIndex, int PageSize);
    }
}
