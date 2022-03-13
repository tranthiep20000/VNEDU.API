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
    /// Dịch vụ của Subject
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public class SubjectService : ISubjectService
    {
        #region Feild
        ISubjectRepository _subjectRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        #endregion

        #region Method
        public int Delete(int SubjectId)
        {
            // Thực hiện xóa dữ liệu vào DB -> công việc này của Repository
            return _subjectRepository.Delete(SubjectId);
        }

        public int Insert(Subject subject)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên môn học không được phép để trống
            if (subject.SubjectName == "" || subject.SubjectName == null)
            {
                errorMsg = "Tên môn học không được phép để trống";
            }


            // 2. Tên môn học không được phép trùng
            else if (_subjectRepository.CheckSubjectName(subject.SubjectName) != null)
            {
                errorMsg = $"Tên môn học < {subject.SubjectName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
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
            return _subjectRepository.Insert(subject);
        }

        public int Update(Subject subject, int SubjectId)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên môn học không được phép để trống
            if (subject.SubjectName == "" || subject.SubjectName == null)
            {
                errorMsg = "Tên môn học không được phép để trống";
            }


            // 2. Tên môn học không được phép trùng
            else if (_subjectRepository.CheckSubjectNameUpdate(subject.SubjectId, subject.SubjectName) == true)
            {
                errorMsg = $"Tên môn học < {subject.SubjectName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
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
            return _subjectRepository.Update(subject, SubjectId);
        }

        #endregion
    }
}
