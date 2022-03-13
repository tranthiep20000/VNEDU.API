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
    /// Dịch vụ của Class
    /// CreatedBy: TTThiep(03/03/2022)
    /// </summary>
    public class ClassService : IClassService
    {
        #region Feild
        IClassRepository _classRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        #endregion

        #region Method
        public int Delete(int ClassId)
        {
            // Thực hiện xóa dữ liệu vào DB -> công việc này của Repository
            return _classRepository.Delete(ClassId);
        }

        public int Insert(Class Class)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên lớp học không được phép để trống
            if (Class.ClassName == "" || Class.ClassName == null)
            {
                errorMsg = "Tên lớp học không được phép để trống";
            }


            // 2. Tên lớp học không được phép trùng
            else if (_classRepository.CheckClassName(Class.ClassName) != null)
            {
                errorMsg = $"Tên lớp học < {Class.ClassName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 3. Tên năm học không được phép để trống
            if (Class.SchoolYearId ==  null)
            {
                errorMsg = "Tên năm học không được phép để trống";
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
            return _classRepository.Insert(Class);
        }

        public int Update(Class Class, int ClassId)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên lớp học không được phép để trống
            if (Class.ClassName == "" || Class.ClassName == null)
            {
                errorMsg = "Tên lớp học không được phép để trống";
            }


            // 2. Tên lớp học không được phép trùng
            else if (_classRepository.CheckClassNameUpdate(Class.ClassId, Class.ClassName) == true)
            {
                errorMsg = $"Tên lớp học < {Class.ClassName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 3. Tên năm học không được phép để trống
            if (Class.SchoolYearId == null)
            {
                errorMsg = "Tên năm học không được phép để trống";
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
            return _classRepository.Update(Class, ClassId);
        }

        #endregion
    }
}
