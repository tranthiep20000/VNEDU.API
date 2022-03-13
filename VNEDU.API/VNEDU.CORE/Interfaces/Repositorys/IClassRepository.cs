using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triền khai Class
    /// CreatedBy: TTThiep(03/03/2022)
    /// </summary>
    public interface IClassRepository : IBaseRepository<Class>
    {
        Class CheckClassName(string ClassName);
        bool CheckClassNameUpdate(int ClassId, string ClassName);
        object GetBySchoolYearId(int SchoolYearId);
    }
}
