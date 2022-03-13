using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triển khai Student_Subject
    /// </summary>
    public interface IStudent_SubjectRepository
    {
        // <summary>
        /// Lấy thông tin theo học sinh, học kì, năm học
        /// </summary>
        /// <returns>Danh sách thông tin</returns>
        /// CreatedBy: TTThiep(04/03/2022)
        Object Get(int StudentId, int SemesterId, int SchoolYearId);

        object GetScoreByStudent(int SchoolYearId, int SemesterId, int StudentId, int ClassId);

        object GetScoreBySubject(int SchoolYearId, int SemesterId, int SubjectId, int ClassId);

        /// <summary>
        /// Thêm thông tin của Student_Subject
        /// </summary>
        /// <param name="student_Subject">Student_Subject</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(04/03/2022)
        int Insert(Student_Subject student_Subject);

        /// <summary>
        /// Xóa thông tin của Student_Class 
        /// </summary>
        /// <param name="StudentId">Khóa chính bảng Student</param>
        /// <param name="SchoolYearId">Khóa chính bảng SchoolYear</param>
        /// <param name="SemesterId">Khóa chính bảng Semester</param>
        /// <param name="SubjectId">Khóa chính bảng Subject</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(04/03/2022)
        int Delete(int StudentId, int SubjectId, int SemesterId, int SchoolYearId);

        object CheckStudentSubject(int SubjectId, int SemesterId, int SchoolYearId, int StudentId);

        Object GetPagingStudentSubjectBySchoolYearSemesterSubjectClass(int SchoolYearId, int SemesterId, int SubjectId, int ClassId, string? ValueFilter, int PageIndex, int PageSize);
    }
}
