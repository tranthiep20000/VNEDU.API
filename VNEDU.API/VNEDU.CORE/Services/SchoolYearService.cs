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
    /// Dịch vụ của SchoolYear
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public class SchoolYearService : ISchoolYearService
    {
        #region Feild
        ISchoolYearRepository _schoolYearRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public SchoolYearService(ISchoolYearRepository schoolYearRepository)
        {
            _schoolYearRepository = schoolYearRepository;
        }
        #endregion

        #region Method
        public int Delete(int SchoolYearId)
        {
            // Thực hiện xóa dữ liệu vào DB -> công việc này của Repository
            return _schoolYearRepository.Delete(SchoolYearId);
        }

        public int Insert(SchoolYear schoolYear)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên năm học không được phép để trống
            if (schoolYear.SchoolYearName == "" || schoolYear.SchoolYearName == null)
            {
                errorMsg = "Tên năm học không được phép để trống";
            }


            // 2. Tên môn học không được phép trùng
            else if (_schoolYearRepository.CheckSchoolYearName(schoolYear.SchoolYearName) != null)
            {
                errorMsg = $"Tên năm học < {schoolYear.SchoolYearName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
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
            return _schoolYearRepository.Insert(schoolYear);
        }

        public int Update(SchoolYear schoolYear, int SchoolYearId)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên năm học không được phép để trống
            if (schoolYear.SchoolYearName == "" || schoolYear.SchoolYearName == null)
            {
                errorMsg = "Tên năm học không được phép để trống";
            }


            // 2. Tên năm học không được phép trùng
            else if (_schoolYearRepository.CheckSchoolYearNameUpdate(schoolYear.SchoolYearId, schoolYear.SchoolYearName) == true)
            {
                errorMsg = $"Tên năm học < {schoolYear.SchoolYearName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
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
            return _schoolYearRepository.Update(schoolYear, SchoolYearId);
        }

        #endregion
    }
}
