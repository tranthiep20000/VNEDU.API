using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Services
{
    /// <summary>
    /// Giao diện dịch vụ của User
    /// CreatedBy: TTThiep(28/02/2022)
    /// </summary>
    public interface IUserService : IBaseService<Used>
    {
        int UpdatePassword(int UserId, string Password);
    }
}
