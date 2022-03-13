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
    /// dịch vụ của người dùng
    /// CreateBy: TTThiep(01/03/2022)
    /// </summary>
    public class UserService : IUserService
    {
        #region Feild
        IUserRepository _userRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Method
        public int Delete(int UserId)
        {
            // Thực hiện xóa dữ liệu vào DB -> công việc này của Repository
            return _userRepository.Delete(UserId);
        }

        public int Insert(Used used)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên người dùng không được phép để trống
            if (used.UserName == "" || used.UserName == null)
            {
                errorMsg = "Tên người dùng không được phép để trống";
            }

            // 2. Số điện thoại không được phép để trống
            else if (used.PhoneNumber == "" || used.PhoneNumber == null)
            {
                errorMsg = "Số điện thoại không được phép để trống";
            }

            // 3. Số điện thoại không được phép trùng
            else if (_userRepository.CheckPhoneNumber(used.PhoneNumber) != null)
            {
                errorMsg = $"Số điện thoại < {used.PhoneNumber} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 4. Tên mật khẩu không được phép để trống
            else if (used.Password == "" || used.Password == null)
            {
                errorMsg = "Tên mật khẩu không được phép để trống";
            }

            else if (used.DecentralizationId == null)
            {
                errorMsg = "Tên quyền không được phép để trống";
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
            return _userRepository.Insert(used);
        }

        public int Update(Used used, int UserId)
        {
            // Thực hiện validate dữ liệu

            // 1. Tên người dùng không được phép để trống
            if (used.UserName == "" || used.UserName == null)
            {
                errorMsg = "Tên người dùng không được phép để trống";
            }

            // 2. Số điện thoại không được phép để trống
            else if (used.PhoneNumber == "" || used.PhoneNumber == null)
            {
                errorMsg = "Số điện thoại không được phép để trống";
            }

            // 3. Số điện thoại không được phép trùng
            else if (_userRepository.CheckPhoneNumberUpdate(used.UserId, used.PhoneNumber) == true)
            {
                errorMsg = $"Số điện thoại < {used.PhoneNumber} > đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            }

            // 4. Tên mật khẩu không được phép để trống
            else if (used.Password == "" || used.Password == null)
            {
                errorMsg = "Tên mật khẩu không được phép để trống";
            }

            else if (used.DecentralizationId == null)
            {
                errorMsg = "Tên quyền không được phép để trống";
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
            return _userRepository.Update(used, UserId);
        }

        public int UpdatePassword(int UserId, string Password)
        {
            // Thực hiện sửa dữ liệu vào DB -> công việc này của Repository
            return _userRepository.UpdatePassword(UserId, Password);
        }

        #endregion
    }
}
