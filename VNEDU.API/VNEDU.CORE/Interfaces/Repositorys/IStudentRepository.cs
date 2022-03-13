using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triển khai Student
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Student CheckStudentCode(string StudentCode);
        bool CheckStudentCodeUpdate(int StudentId, string StudentCode);
        Student CheckPhoneNumber(string PhoneNumber);
        bool CheckPhoneNumberUpdate(int StudentId, string PhoneNumber);

        Object GetInformationStudentByPhoneNumber(string PhoneNumber);

        Object GetPagingStudent(string? ValueFilter, int PageIndex, int PageSize);
    }
}
