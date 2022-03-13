using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triển khai Subject
    /// </summary>
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Subject CheckSubjectName(string SubjectName);
        bool CheckSubjectNameUpdate(int SubjectId, string SubjectName);
    }
}
