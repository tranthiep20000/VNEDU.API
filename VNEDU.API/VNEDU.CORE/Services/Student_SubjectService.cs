using MISA.AMIS.CORE.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;
using VNEDU.CORE.Interfaces.Repositorys;
using VNEDU.CORE.Interfaces.Services;

namespace VNEDU.CORE.Services
{
    /// <summary>
    /// Dịch vụ của Student_Subject
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public class Student_SubjectService : IStudent_SubjectService
    {
        #region Feild
        IStudent_SubjectRepository _student_SubjectRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public Student_SubjectService(IStudent_SubjectRepository student_SubjectRepository)
        {
            _student_SubjectRepository = student_SubjectRepository;
        }
        #endregion

        #region Method
        public int Delete(int StudentId, int SubjectId, int SemesterId, int SchoolYearId)
        {
            // Thực hiện xóa dữ liệu vào DB -> công việc này của Repository
            return _student_SubjectRepository.Delete(StudentId, SubjectId, SemesterId, SchoolYearId);
        }

        public int Insert(Student_Subject student_Subject)
        {
            // Thực hiện validate dữ liệu
            // Thực hiện validate dữ liệu
            // 1. Tên lớp học và học sinh không được phép trùng
            if (_student_SubjectRepository.CheckStudentSubject(student_Subject.SubjectId, student_Subject.SemesterId, student_Subject.SchoolYearId, student_Subject.StudentId) != null)
            {
                errorMsg = $"Học sinh này đã học môn học này trong học kì và năm học này, vui lòng kiểm tra lại.";
            }
            if (errorMsg != "")
            {
                var result = new
                {
                    devMsg = errorMsg,
                    userMsg = errorMsg,
                    error = "dữ liệu không hợp lệ, vui lòng kiểm tra lại"
                };
                throw new ValidateException(result);
            }
            // Thực hiện thêm mới dữ liệu vào DB -> công việc này của Repository
            return _student_SubjectRepository.Insert(student_Subject);
        }
        #endregion
    }
}
