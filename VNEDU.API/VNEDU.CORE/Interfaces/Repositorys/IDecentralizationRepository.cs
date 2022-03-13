using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    public interface IDecentralizationRepository : IBaseRepository<Decentralization>
    {
        Decentralization CheckDecentralizationName(string DecentralizationName);

        bool CheckDecentralizationNameUpdate(int DecentralizationId, string DecentralizationName);
    }
}
