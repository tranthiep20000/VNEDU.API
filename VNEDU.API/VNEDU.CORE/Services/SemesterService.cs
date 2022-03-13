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
    /// Dịch vụ của Semester
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public class SemesterService : ISemesterService
    {
        #region Feild
        ISemesterRepository _semesterRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public SemesterService(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }
        #endregion

        #region Method
        public int Delete(int SemesterId)
        {
            // Thực hiện xóa dữ liệu vào DB -> công việc này của Repository
            return _semesterRepository.Delete(SemesterId);
        }

        public int Insert(Semester semester)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên học kì không được phép để trống
            if (semester.SemesterName == "" || semester.SemesterName == null)
            {
                errorMsg = "Tên học kì không được phép để trống";
            }


            // 2. Tên học kì không được phép trùng
            else if (_semesterRepository.CheckSemesterName(semester.SemesterName) != null)
            {
                errorMsg = $"Tên học kì < {semester.SemesterName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
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
            return _semesterRepository.Insert(semester);
        }

        public int Update(Semester semester, int SemesterId)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên học kì không được phép để trống
            if (semester.SemesterName == "" || semester.SemesterName == null)
            {
                errorMsg = "Tên học kì không được phép để trống";
            }


            // 2. Tên học kì không được phép trùng
            else if (_semesterRepository.CheckSemesterNameUpdate(semester.SemesterId, semester.SemesterName) == true)
            {
                errorMsg = $"Tên học kì < {semester.SemesterName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
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

            // Thực hiện sửa dữ liệu vào DB -> công việc này của Repository
            return _semesterRepository.Update(semester, SemesterId);
        }

        #endregion
    }
}
