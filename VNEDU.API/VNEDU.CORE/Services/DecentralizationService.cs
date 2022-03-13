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
    public class DecentralizationService : IDecentralizationService
    {
        #region Feild
        IDecentralizationRepository _decentralizationRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public DecentralizationService(IDecentralizationRepository decentralizationRepository)
        {
            _decentralizationRepository = decentralizationRepository;
        }
        #endregion

        #region Method
        public int Delete(int DecentralizationId)
        {
            // Thực hiện xóa dữ liệu vào DB -> công việc này của Repository
            return _decentralizationRepository.Delete(DecentralizationId);
        }

        public int Insert(Decentralization decentralization)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên quyền không được phép để trống
            if (decentralization.DecentralizationName == "" || decentralization.DecentralizationName == null)
            {
                errorMsg = "Tên quyền không được phép để trống";
            }

            // 2. Tên quyền không được phép trùng
            else if (_decentralizationRepository.CheckDecentralizationName(decentralization.DecentralizationName) != null)
            {
                errorMsg = $"Tên quyền < {decentralization.DecentralizationName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 3. Mô tả quyền không được phép để trống
            else if (decentralization.Description == "" || decentralization.Description == null)
            {
                errorMsg = "Mô tả quyền không được phép để trống";
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
            return _decentralizationRepository.Insert(decentralization);
        }

        public int Update(Decentralization decentralization, int DecentralizationId)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên quyền không được phép để trống
            if (decentralization.DecentralizationName == "" || decentralization.DecentralizationName == null)
            {
                errorMsg = "Tên quyền không được phép để trống";
            }

            // 2. Tên quyền không được phép trùng
            else if (_decentralizationRepository.CheckDecentralizationNameUpdate(decentralization.DecentralizationId, decentralization.DecentralizationName) == true)
            {
                errorMsg = $"Tên quyền < {decentralization.DecentralizationName} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 3. Mô tả quyền không được phép để trống
            else if (decentralization.Description == "" || decentralization.Description == null)
            {
                errorMsg = "Mô tả quyền không được phép để trống";
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
            return _decentralizationRepository.Update(decentralization, DecentralizationId);
        }

        #endregion
    }
}
