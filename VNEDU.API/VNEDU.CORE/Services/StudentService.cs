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
    /// Dịch vụ của Student
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public class StudentService : IStudentService
    {
        #region Feild
        IStudentRepository _studentRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        #endregion

        #region Method
        public int Delete(int StudentId)
        {
            // Thực hiện xóa dữ liệu vào DB -> công việc này của Repository
            return _studentRepository.Delete(StudentId);
        }

        public int Insert(Student student)
        {
            // Thực hiện validate dữ liệu

            // 1. Mã học sinh không được phép để trống
            if (student.StudentCode == "" || student.StudentCode == null)
            {
                errorMsg = "Mã học sinh không được phép để trống";
            }


            // 2. Mã học sinh không được phép trùng
            else if (_studentRepository.CheckStudentCode(student.StudentCode) != null)
            {
                errorMsg = $"Mã học sinh < {student.StudentCode} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 3. Tên học sinh không được phép để trống
            else if (student.FullName == "" || student.FullName == null)
            {
                errorMsg = "Tên học sinh không được phép để trống";
            }

            // 4. Giới tính không được phép để trống
            else if (student.Gender == null)
            {
                errorMsg = "Giới tính không được phép để trống";
            }

            // 5. Ngày sinh không được phép để trống
            else if (student.DateOfBirth.ToString() == null || student.DateOfBirth.ToString() == "")
            {
                errorMsg = "Ngày sinh không được phép để trống";
            }

            // 6. Số điện thoại không được phép để trống
            else if (student.PhoneNumber == "" || student.PhoneNumber == null)
            {
                errorMsg = "Số điện thoại không được phép để trống";
            }

            // 7. Số điện thoại không được phép trùng
            else if (_studentRepository.CheckPhoneNumber(student.PhoneNumber) != null)
            {
                errorMsg = $"Số điện thoại < {student.PhoneNumber} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 8. Địa chỉ không được phép để trống
            else if (student.Address == "" || student.Address == null)
            {
                errorMsg = "Địa chỉ không được phép để trống";
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
            return _studentRepository.Insert(student);
        }

        public int Update(Student student, int StudentId)
        {
            // Thực hiện validate dữ liệu

            // 1. Mã học sinh không được phép để trống
            if (student.StudentCode == "" || student.StudentCode == null)
            {
                errorMsg = "Mã học sinh không được phép để trống";
            }


            // 2. Mã học sinh không được phép trùng
            else if (_studentRepository.CheckStudentCodeUpdate(student.StudentId, student.StudentCode) == true)
            {
                errorMsg = $"Mã học sinh < {student.StudentCode} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 3. Tên học sinh không được phép để trống
            else if (student.FullName == "" || student.FullName == null)
            {
                errorMsg = "Tên học sinh không được phép để trống";
            }

            // 4. Giới tính không được phép để trống
            else if (student.Gender == null)
            {
                errorMsg = "Giới tính không được phép để trống";
            }

            // 5. Ngày sinh không được phép để trống
            else if (student.DateOfBirth.ToString() == null || student.DateOfBirth.ToString() == "")
            {
                errorMsg = "Ngày sinh không được phép để trống";
            }

            // 6. Số điện thoại không được phép để trống
            else if (student.PhoneNumber == "" || student.PhoneNumber == null)
            {
                errorMsg = "Số điện thoại không được phép để trống";
            }

            // 7. Số điện thoại không được phép trùng
            else if (_studentRepository.CheckPhoneNumberUpdate(student.StudentId, student.PhoneNumber) == true)
            {
                errorMsg = $"Số điện thoại < {student.PhoneNumber} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 8. Địa chỉ không được phép để trống
            else if (student.Address == "" || student.Address == null)
            {
                errorMsg = "Địa chỉ không được phép để trống";
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
            return _studentRepository.Update(student, StudentId);
        }

        #endregion
    }
}
