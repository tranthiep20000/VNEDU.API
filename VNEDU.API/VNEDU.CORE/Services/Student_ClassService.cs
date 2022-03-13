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
    /// Dịch vụ của Student_Class
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public class Student_ClassService : IStudent_ClassService
    {
        #region Feild
        IStudent_ClassRepository _student_ClassRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public Student_ClassService(IStudent_ClassRepository student_ClassRepository)
        {
            _student_ClassRepository = student_ClassRepository;
        }
        #endregion

        #region Method
        public int Delete(int StudentId, int ClassId, int SemesterId, int SchoolYearId)
        {
            // Thực hiện xóa dữ liệu vào DB -> công việc này của Repository
            return _student_ClassRepository.Delete(StudentId, ClassId, SemesterId, SchoolYearId);
        }

        public int Insert(Student_Class student_Class)
        {
            // Thực hiện validate dữ liệu
            // 1. Tên lớp học và học sinh không được phép trùng
            if (_student_ClassRepository.CheckStudentClass(student_Class.SchoolYearId, student_Class.SemesterId, student_Class.ClassId, student_Class.StudentId) != null)
            {
                errorMsg = $"Học sinh này đã học lớp học trong học kì và năm học này, vui lòng kiểm tra lại.";
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
            return _student_ClassRepository.Insert(student_Class);
        }
        #endregion
    }
}
