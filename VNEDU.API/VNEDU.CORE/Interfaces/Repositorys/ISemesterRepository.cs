using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triển khai Semester
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public interface ISemesterRepository : IBaseRepository<Semester>
    {
        Semester CheckSemesterName(string SemesterName);
        bool CheckSemesterNameUpdate(int SemesterId, string SemesterName);
    }
}
