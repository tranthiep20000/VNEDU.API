using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triển khai User
    /// CreateBy: TTThiep(28/02/2022)
    /// </summary>
    public interface IUserRepository : IBaseRepository<Used>
    {
        Used CheckPhoneNumber(string PhoneNumber);
        bool CheckPhoneNumberUpdate(int UserId, string PhoneNumber);

        object GetUserByPhoneNumberPassword(string PhoneNumber, string Password);

        int UpdatePassword(int UserId, string Password);

        Object GetPagingUser(string? ValueFilter, int PageIndex, int PageSize);
    }
}
