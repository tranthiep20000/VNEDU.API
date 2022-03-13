using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triển khai SchoolYear
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public interface ISchoolYearRepository : IBaseRepository<SchoolYear>
    {
        SchoolYear CheckSchoolYearName(string SchoolYearName);
        bool CheckSchoolYearNameUpdate(int SchoolYearId, string SchoolYearName);
    }
}
